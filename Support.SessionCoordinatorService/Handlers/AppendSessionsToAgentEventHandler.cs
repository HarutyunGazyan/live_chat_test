using Shared.Library.EventBus.Abstractions;
using Shared.Library.EventBus.Events;
using SessionCoordinatorService.Services;

namespace SessionCoordinatorService.Handlers
{
    public class AppendSessionsToAgentEventHandler : IIntegrationEventHandler<AppendSessionsToAgentEvent>
    {
        private readonly SessionManagementService _sessionManagementService;

        public AppendSessionsToAgentEventHandler(SessionManagementService sessionManagementService)
        {
            _sessionManagementService = sessionManagementService;
        }

        public async Task<bool> Handle(AppendSessionsToAgentEvent @event)
        {
            return await _sessionManagementService.AppendToAgent();
        }
    }
}
