using Shared.Library.Entities;

namespace SessionCoordinatorService.Services
{
    public interface ISupportRepository
    {
        Task DeleteActiveAgentSessionAsync(ActiveAgentSession session);
        Task AddActiveAgentSessionAsync(ActiveAgentSession activeAgentSession);
        Task AddToSessionQueueAsync(SessionQueueItem sessionQueue);
        Task<ActiveAgentSession> GetActiveAgentSessionAsync(Guid sessionId);
        Task<List<Team>> GetActiveTeamsAsync();
        Task<Agent> GetAgentWithCapacityAsync();
        Task<Team> GetOverflowTeamAsync();
        Task<List<SessionQueueItem>> GetOrderedSessionQueueAsync();
        Task<int> GetSessionQueueCountAsync();
        Task DeleteFromSessionQueueAsync(SessionQueueItem sessionToRemove);
        Task UpdateTeamAsync(Team team);
        Task<SessionQueueItem> GetSessionByIdAsync(Guid sessionId);
        Task DeleteActiveAgentSessionsAsync(List<ActiveAgentSession> agentSessions);
        Task DeleteFromSessionQueueAsync(List<SessionQueueItem> sessionsToRemove);
        Task<List<ActiveAgentSession>> GetActiveAgentSessionsAsync();
    }
}
