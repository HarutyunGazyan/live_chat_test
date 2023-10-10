using Quartz;
using SessionCoordinatorService.Services;

namespace SessionCoordinatorService.Handlers
{
    public class ResetOverflowHandler : IJob
    {
        private readonly SessionManagementService _sessionManagementService;

        public ResetOverflowHandler(SessionManagementService sessionManagementService)
        {
            _sessionManagementService = sessionManagementService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _sessionManagementService.DeactivateOverflowTeam();
        }
    }
}
