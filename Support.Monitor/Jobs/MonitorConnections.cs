using MongoDB.Driver;
using Quartz;
using Shared.Library.EventBus.Abstractions;
using Shared.Library.EventBus.Events;

namespace Monitor.Jobs
{
    public class MonitorConnections : IJob
    {
        private readonly ConnectionService _connectionService;
        private readonly IEventBus _eventBus;

        public MonitorConnections(ConnectionService connectionService, IEventBus eventBus)
        {
            _connectionService = connectionService;
            _eventBus = eventBus;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var sessionsToCancell = await _connectionService.sessionCollection.Find(x => x.ExpireAt < DateTime.UtcNow).ToListAsync();

            foreach (var session in sessionsToCancell)
            {
                _eventBus.Publish(new SessionCancelledEvent { SessionId = session.Id });
            }

            await _connectionService.sessionCollection.DeleteManyAsync(x => sessionsToCancell.Select(x => x.Id).Contains(x.Id));
        }
    }
}
