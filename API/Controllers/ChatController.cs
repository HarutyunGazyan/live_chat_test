using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Shared.Library.DTOs;
using Shared.Library.Entities;
using Shared.Library.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly SessionService _sessionService;
        private readonly SupportDbContext _supportDbContext;
        private readonly HttpClient _httpClient;

        public ChatController(SessionService sessionService, IHttpClientFactory httpClientFactory, SupportDbContext supportDbContext)
        {
            _sessionService = sessionService;
            _supportDbContext = supportDbContext;
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost(nameof(Start))]
        public async Task<IActionResult> Start()
        {
            var httpResponseMessage = await _httpClient.PostAsync("https://localhost:7010/Session/Create", null);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return StatusCode(500);
            }

            var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();

            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<SessionCreatedResponse>(jsonString);

            try
            {
                await _sessionService.sessionCollection.InsertOneAsync(new Session { Id = response.SessionId, ExpireAt = DateTime.UtcNow.AddSeconds(3) });
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
            var value = await _sessionService.sessionCollection.Find(x => x.Id == sessionId).FirstOrDefaultAsync();
            if (value == null)
            {
                return BadRequest();
            }

            value.ExpireAt = DateTime.UtcNow;

            await _sessionService.sessionCollection.ReplaceOneAsync(x => x.Id == sessionId, value);

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
    }
}
