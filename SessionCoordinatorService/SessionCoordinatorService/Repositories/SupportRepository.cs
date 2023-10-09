using SessionCoordinatorService.Entities;
using SessionCoordinatorService.Services;

namespace SessionCoordinatorService.Repositories
{
    public class SupportRepository : ISupportRepository
    {
        public Task AddActiveAgentSessions(List<ActiveAgentSession> activeAgentSessions)
        {
            throw new NotImplementedException();
        }

        public Task AddToSessionQueue(SessionQueueItem sessionQueue)
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetActiveTeam()
        {
            throw new NotImplementedException();
        }

        public Task<List<Agent>> GetAgentsWithCapacity()
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetOverflowInfo()
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetOverflowTeam()
        {
            throw new NotImplementedException();
        }

        public Task<List<SessionQueueItem>> GetSessionQueue()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetSessionQueueCount()
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromSessionsQueue(List<SessionQueueItem> sessionsToRemove)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Team overflowTeam)
        {
            throw new NotImplementedException();
        }
    }
}
