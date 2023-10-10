using Shared.Library.EventBus.Abstractions;
using Shared.Library.EventBus.Events;
using SessionCoordinatorService.Services;

namespace SessionCoordinatorService.Handlers
{
    public class SessionCancelledEventHandler : IIntegrationEventHandler<SessionCancelledEvent>
    {
        private readonly SessionManagementService _sessionManagementService;
        private readonly IEventBus _eventBus;

        public SessionCancelledEventHandler(SessionManagementService sessionManagementService, IEventBus eventBus)
        {
            _sessionManagementService = sessionManagementService;
            _eventBus = eventBus;
        }

        public async Task<bool> Handle(SessionCancelledEvent @event)
        {
            var result = await _sessionManagementService.RemoveSession(@event.SessionId);
            _eventBus.Publish(new AppendSessionsToAgentEvent());

            return result;
        }
    }
}
