using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Net.Http;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly SessionService _sessionService;
        private readonly HttpClient _httpClient;

        public ChatController(SessionService sessionService, IHttpClientFactory httpClientFactory)
        {
            _sessionService = sessionService;
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost("start")]
        public async Task<IActionResult> Start()
        {
            var httpResponseMessage = await _httpClient.PostAsync("https://localhost:7010/Session/Create", null);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return StatusCode(500);
            }

            var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
            var isParsed = Guid.TryParse(contentStream, out Guid key);

            if (!isParsed || key == Guid.Empty)
            {
                return StatusCode(500);
            }

            try
            {
                await _sessionService.sessionCollection.InsertOneAsync(new Session { Id = key, ExpireAt = DateTime.UtcNow.AddSeconds(3) });
            }
            catch (Exception ex)
            {
                var x = ex;
            }

            return Ok(key);
        }

        [HttpGet("poll")]
        public async Task<IActionResult> Poll(Guid key)
        {
            var value = await _sessionService.sessionCollection.Find(x => x.Id == key).FirstOrDefaultAsync();
            if (value == null)
            {
                return BadRequest();
            }

            value.ExpireAt = DateTime.UtcNow;

            await _sessionService.sessionCollection.ReplaceOneAsync(x => x.Id == key, value);

            return Ok(value);
        }
        public class Date
        {
            public DateTime DateTime { get; set; }
        }
    }
}
