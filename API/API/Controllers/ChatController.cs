using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly SessionService _sessionService;

        public ChatController(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost("start")]
        public async Task<IActionResult> Start()
        {
            var key = Guid.NewGuid();
            try
            {
                await _sessionService.sessionCollection.InsertOneAsync(new Session { Id = key, ExpireAt = DateTime.UtcNow.AddSeconds(3) });
            }
            catch(Exception ex)
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
