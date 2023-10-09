namespace SessionCoordinatorService.Services
{
    public class SessionManagementService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionManagementService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }


    }
}
