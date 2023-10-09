using Microsoft.AspNetCore.Mvc;
using SessionCoordinatorService.Services;

namespace SessionCoordinatorService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ILogger<SessionController> _logger;
        private readonly SessionManagementService _sessionManagementService;

        public SessionController(ILogger<SessionController> logger, SessionManagementService sessionManagementService)
        {
            _logger = logger;
            _sessionManagementService = sessionManagementService;
        }

        [HttpPost(nameof(Create))]
        public async Task<IActionResult> Create()
        {
            var sessionId = await _sessionManagementService.GenerateSession();

            if(sessionId == null)
            {
                return StatusCode(204);
            }

            return Ok(sessionId);
        }
    }
}