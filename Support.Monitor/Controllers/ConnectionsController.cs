using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Shared.Library.Services;
using Support.Shared.Lib.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionsController : ControllerBase
    {
        private readonly ConnectionService _connectionService;

        public ConnectionsController(ConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetActiveConnections()
        {
            var connections = await _connectionService.GetAsync();

            if (!connections.Any())
            {
                return NoContent();
            }

            return Ok(new GetActiveConnectionsResponse { ActiveConnections = connections.Select(x => x.Id).ToList() });
        }
    }
}
