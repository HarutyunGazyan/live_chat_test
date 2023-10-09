using Shared.Library.EventBus.Abstractions;
using Shared.Library.EventBus.Events;
using SessionCoordinatorService.Services;

namespace SessionCoordinatorService.Handlers
{
    public class SessionCancelledEventHandler : IIntegrationEventHandler<SessionCancelledEvent>
    {
        private readonly SessionManagementService _sessionManagementService;

        public SessionCancelledEventHandler(SessionManagementService sessionManagementService)
        {
            _sessionManagementService = sessionManagementService;
        }

        public async Task<bool> Handle(SessionCancelledEvent @event)
        {
            return await _sessionManagementService.RemoveSession(@event.SessionId);

        }
    }
}
