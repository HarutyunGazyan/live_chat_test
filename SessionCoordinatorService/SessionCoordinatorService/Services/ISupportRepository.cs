using SessionCoordinatorService.Entities;

namespace SessionCoordinatorService.Services
{
    public interface ISupportRepository
    {
        Task AddActiveAgentSessions(List<ActiveAgentSession> activeAgentSessions);
        Task AddToSessionQueue(SessionQueueItem sessionQueue);
        Task<Team> GetActiveTeam();
        Task<List<Agent>> GetAgentsWithCapacity();
        Task<bool> GetOverflowInfo();
        Task<Team> GetOverflowTeam();
        Task<List<SessionQueueItem>> GetSessionQueue();
        Task<int> GetSessionQueueCount();
        Task RemoveFromSessionsQueue(List<SessionQueueItem> sessionsToRemove);
        Task UpdateAsync(Team overflowTeam);
    }
}
