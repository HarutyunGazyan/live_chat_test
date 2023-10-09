using RabbitMQ.Lib.EventBus.Abstractions;
using RabbitMQ.Lib.EventBus.Events;
using SessionCoordinatorService.Entities;

namespace SessionCoordinatorService.Handlers
{
    public class AppendSessionToAgentEventHandler : IIntegrationEventHandler<AppendSessionToAgentEvent>
    {
        private readonly SupportDbContext _dbContext;

        public AppendSessionToAgentEventHandler(SupportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> Handle(AppendSessionToAgentEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
