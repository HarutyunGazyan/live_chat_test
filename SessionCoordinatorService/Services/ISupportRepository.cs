using Shared.Library.Entities;

namespace SessionCoordinatorService.Services
{
    public interface ISupportRepository
    {
        Task DeleteActiveAgentSession(ActiveAgentSession session);
        Task AddActiveAgentSession(ActiveAgentSession activeAgentSession);
        Task AddToSessionQueue(SessionQueueItem sessionQueue);
        Task<ActiveAgentSession> GetActiveAgentSession(Guid sessionId);
        Task<List<Team>> GetActiveTeams();
        Task<Agent> GetAgentWithCapacity();
        Task<Team> GetOverflowTeam();
        Task<List<SessionQueueItem>> GetOrderedSessionQueue();
        Task<int> GetSessionQueueCount();
        Task RemoveFromSessionQueue(SessionQueueItem sessionToRemove);
        Task UpdateTeamAsync(Team team);
    }
}
