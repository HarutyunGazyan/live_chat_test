using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Caching;

namespace Chat.Controllers;

[Route("api/chat")]
public class ChatController : AbpController
{
    private readonly IDistributedCache<Date, Guid> _cache;

    public ChatController(IDistributedCache<Date, Guid> cache)
    {
        _cache = cache;
    }

    [HttpPost("start")]
    public async Task<IActionResult> Start()
    {
        var key = Guid.NewGuid();
        await _cache.SetAsync(key, new Date { DateTime = DateTime.UtcNow });

        return Ok(key);
    }

    [HttpGet("poll")]
    public async Task<IActionResult> Poll(Guid key)
    {
        var value = await _cache.GetAsync(key);
        if(value == null)
        {
            return BadRequest();
        }

        await _cache.SetAsync(key, new Date { DateTime = DateTime.UtcNow });

        return Ok();
    }
    public class Date
    {
        public DateTime DateTime { get; set; }
    }
}