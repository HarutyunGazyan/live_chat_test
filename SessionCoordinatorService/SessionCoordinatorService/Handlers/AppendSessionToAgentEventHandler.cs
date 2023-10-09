using RabbitMQ.Lib.EventBus.Abstractions;
using RabbitMQ.Lib.EventBus.Events;
using SessionCoordinatorService.Services;

namespace SessionCoordinatorService.Handlers
{
    public class AppendSessionToAgentEventHandler : IIntegrationEventHandler<MonitorSessionQueueEvent>
    {
        private readonly SessionManagementService _sessionManagementService;

        public AppendSessionToAgentEventHandler(SessionManagementService sessionManagementService)
        {
            _sessionManagementService = sessionManagementService;
        }

        public async Task<bool> Handle(MonitorSessionQueueEvent @event)
        {
            return await _sessionManagementService.AppendToAgent();
        }
    }
}
