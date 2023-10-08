using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessionCoordinatorService.Entities;
using System.Runtime.Intrinsics.X86;

namespace SessionCoordinatorService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly SupportDbContext _dbContext;

        public SessionController(ILogger<WeatherForecastController> logger, SupportDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost(nameof(Create))]
        public async Task<IActionResult> Create()
        {
            //1) find out current active teams
            //2) calculate team capacity, max queue length
            //3) check current queue length,
            //if >= capacity*1.5{
            //if overflow availabe and not active{
            //activate overflow,
            //recaulculate queue length,
            // add to queue
            //}
            //else reject
            //}else
            //{
            //add to queue a message called - monitor_queue
            //(session_queue) should have a subscriber which will:
            //open a TNX
            //check for a free agent as shown below
            //if agent found
            //{
            //append sessionid to ActiveAgentSessions
            // commit tnx
            // ack message in a queue
            //}
            //else
            //{
            // revert TNX
            // make sure the message stayed in a queue
            //}

            //once the session chat is being closed, from a client, or by Monitor, or from an agent,
            //the session should be deleted from ActiveAgentSessions
            //monitor_queue message should be published to make sure that a free agent can receive a new session

            //there should be a monitor on deactivating Overflow team at the end of the day (or once the  queue length is <= 1.5 * main team capacity)



            //var queueMessageCount = GetQueueMessageCount();
            var agent = await _dbContext.Agents
                            .Include(x => x.Team)
                            .Include(x => x.ActiveAgentSessions)
                            .Include(x => x.Seniority)
                            .OrderBy(x => x.Seniority.Priority)
                            .FirstOrDefaultAsync(x =>
                                x.Team.WorkFinishHourAt > DateTime.Now.Hour &&
                                x.Team.WorkStartHourAt < DateTime.Now.Hour &&
                                x.ActiveAgentSessions.Count < x.Seniority.SeniorityMultiplier &&
                                x.Team.Active
                                );
            
            if(agent == null)
            {
                //check for queue availability (team capacity times 1.5)
            }
            
            return Ok();
        }
    }
}