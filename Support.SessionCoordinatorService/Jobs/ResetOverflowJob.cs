using Quartz;
using SessionCoordinatorService.Services;

namespace SessionCoordinatorService.Jobs
{
    public class ResetOverflowJob : IJob
    {
        private readonly SessionManagementService _sessionManagementService;

        public ResetOverflowJob(SessionManagementService sessionManagementService)
        {
            _sessionManagementService = sessionManagementService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _sessionManagementService.DeactivateOverflowTeam();
        }
    }
}
