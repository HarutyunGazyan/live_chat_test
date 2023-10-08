using MongoDB.Driver;
using Quartz;

namespace Monitor.Jobs
{
    public class MonitorSessions : IJob
    {
        private readonly SessionService _sessionService;

        public MonitorSessions(SessionService sessionService)
        {
            _sessionService = sessionService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var sessionsToCancell = await _sessionService.sessionCollection.Find(x => x.ExpireAt < DateTime.UtcNow).ToListAsync();

            await _sessionService.sessionCollection.DeleteManyAsync(x => sessionsToCancell.Select(x => x.Id).Contains(x.Id));
        }
    }
}
