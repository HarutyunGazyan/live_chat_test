using MongoDB.Driver;
using Quartz;
using Shared.Library.EventBus.Abstractions;
using Shared.Library.EventBus.Events;

namespace Monitor.Jobs
{
    public class MonitorSessions : IJob
    {
        private readonly SessionService _sessionService;
        private readonly IEventBus _eventBus;

        public MonitorSessions(SessionService sessionService, IEventBus eventBus)
        {
            _sessionService = sessionService;
            _eventBus = eventBus;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var sessionsToCancell = await _sessionService.sessionCollection.Find(x => x.ExpireAt < DateTime.UtcNow).ToListAsync();

            foreach (var session in sessionsToCancell)
            {
                _eventBus.Publish(new SessionCancelledEvent { SessionId = session.Id });
            }

            await _sessionService.sessionCollection.DeleteManyAsync(x => sessionsToCancell.Select(x => x.Id).Contains(x.Id));
        }
    }
}
