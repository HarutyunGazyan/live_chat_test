using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Shared.Library.DTOs;
using Shared.Library.Entities;
using Shared.Library.EventBus.Abstractions;
using Shared.Library.EventBus.Events;
using Shared.Library.Extensions;
using Shared.Library.Services;
using Shared.Library.Services.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ConnectionService _connectionService;
        private readonly SupportDbContext _supportDbContext;
        private readonly IEventBus _eventBus;
        private readonly IHttpClientFactory _httpClientFactory;

        public ChatController(ConnectionService connectionService, IHttpClientFactory httpClientFactory, SupportDbContext supportDbContext, IEventBus eventBus)
        {
            _connectionService = connectionService;
            _supportDbContext = supportDbContext;
            _eventBus = eventBus;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost(nameof(Start))]
        public async Task<IActionResult> Start()
        {
            var httpResponseMessage = await _httpClientFactory.CreateClient().PostAsync("https://localhost:7010/Session/Create", null);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return StatusCode(500);
            }

            var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();

            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<SessionCreatedResponse>(jsonString);

            try
            {
                await _connectionService.CreateAsync(new SessionConnection { Id = response.SessionId, ExpireAt = DateTime.UtcNow.AddSeconds(3) });
            }
            catch (Exception ex)
            {
                var x = ex;
            }

            return Ok(response);
        }

        [HttpGet(nameof(Poll))]
        public async Task<IActionResult> Poll(Guid sessionId, DateTime? pullMessagesFrom = null)
        {
            var value = await _connectionService.GetAsync(sessionId);
            if (value == null)
            {
                return BadRequest();
            }

            value.ExpireAt = DateTime.UtcNow.AddSeconds(3);

            await _connectionService.UpdateAsync(sessionId, value);

            var isAppendedToAgent = await _supportDbContext.ActiveAgentSessions.AnyAsync(x => x.SessionId == sessionId);

            if (!isAppendedToAgent)
            {
                return Ok();
            }

            var query = _supportDbContext.SessionChats.Include(x => x.Agent).Where(x => x.SessionId == sessionId);

            if (pullMessagesFrom != null)
            {
                query = query.Where(x => x.SentAt >= pullMessagesFrom.Value);
            }
            var messages = await query.ToListAsync();

            return Ok(messages.Select(x => new PollResponse
            {
                MessageBody = x.MessageBody,
                AgentName = x.Agent.Name,
                SentAt = x.SentAt,
                SentBy = x.SentBy
            }));
        }

        [HttpGet(nameof(GetAgentMessages))]
        public async Task<IActionResult> GetAgentMessages(Guid agentId, DateTime? pullMessagesFrom = null)
        {
            var query = _supportDbContext.SessionChats.Where(x => x.AgentId == agentId && x.Agent.ActiveAgentSessions.Any(y => y.SessionId == x.SessionId));

            if (pullMessagesFrom != null)
            {
                query = query.Where(x => x.SentAt >= pullMessagesFrom.Value);
            }
            var messages = await query.ToListAsync();
            return Ok(messages);
        }

        [HttpPost(nameof(SendMessage))]
        public async Task<IActionResult> SendMessage(SendMessageRequest request)
        {
            var message = new SessionMessage { Id = Guid.NewGuid(), SessionId = request.SessionId, MessageBody = request.Body };
            if (request.AgentId == null)//sent by client
            {
                var activeAgent = await _supportDbContext.ActiveAgentSessions.SingleOrDefaultAsync(x => x.SessionId == request.SessionId);
                if (activeAgent == null)
                {
                    return StatusCode(400);
                }

                message.AgentId = activeAgent.Id;
                message.SentBy = Constants.SentByClient;
            }
            else
            {
                message.AgentId = request.AgentId.Value;
                message.SentBy = Constants.SentByAgent;
            }

            await _supportDbContext.SessionChats.AddAsync(message);
            await _supportDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete(nameof(CancellSession))]
        public async Task<IActionResult> CancellSession(CancellSessionRequest request)
        {
            _eventBus.Publish(new SessionCancelledEvent { SessionId = request.SessionId, CancelledBy = request.AgentId?.ToString() ?? "Client" });

            return Ok();
        }
    }
}
