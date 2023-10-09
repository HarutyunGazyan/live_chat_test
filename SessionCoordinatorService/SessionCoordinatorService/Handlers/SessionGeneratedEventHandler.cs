using RabbitMQ.Lib.EventBus.Abstractions;
using RabbitMQ.Lib.EventBus.Events;
using SessionCoordinatorService.Services;

namespace SessionCoordinatorService.Handlers
{
    public class SessionGeneratedEventHandler : IIntegrationEventHandler<SessionGeneratedEvent>
    {
        private readonly SessionManagementService _sessionManagementService;

        public SessionGeneratedEventHandler(SessionManagementService sessionManagementService)
        {
            _sessionManagementService = sessionManagementService;
        }

        public async Task<bool> Handle(SessionGeneratedEvent @event)
        {
            return await _sessionManagementService.AppendToAgent();
        }
    }
}
