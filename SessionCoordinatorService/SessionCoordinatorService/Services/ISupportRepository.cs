using SessionCoordinatorService.Entities;

namespace SessionCoordinatorService.Services
{
    public interface ISupportRepository
    {
        Task DeleteActiveAgentSession(ActiveAgentSession session);
        Task AddActiveAgentSessions(List<ActiveAgentSession> activeAgentSessions);
        Task AddToSessionQueue(SessionQueueItem sessionQueue);
        Task<ActiveAgentSession> GetActiveAgentSession(Guid sessionId);
        Task<Team> GetActiveTeam();
        Task<List<Agent>> GetAgentsWithCapacity();
        Task<Team> GetOverflowTeam();
        Task<List<SessionQueueItem>> GetSessionQueue();
        Task<int> GetSessionQueueCount();
        Task RemoveFromSessionsQueue(List<SessionQueueItem> sessionsToRemove);
        Task UpdateAsync(Team overflowTeam);
        Task UpdateOverflowTeam(Team overflowTeam);
    }
}
