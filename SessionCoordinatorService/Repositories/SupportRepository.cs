using Microsoft.EntityFrameworkCore;
using Shared.Library.Entities;
using SessionCoordinatorService.Services;
using Shared.Library.Extensions;

namespace SessionCoordinatorService.Repositories
{
    public class SupportRepository : ISupportRepository
    {
        private readonly SupportDbContext _dbContext;

        public SupportRepository(SupportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddActiveAgentSession(ActiveAgentSession activeAgentSession)
        {
            await _dbContext.ActiveAgentSessions.AddRangeAsync(activeAgentSession);

            await _dbContext.SaveChangesAsync();
        }

        public async Task AddToSessionQueue(SessionQueueItem sessionQueue)
        {
            await _dbContext.SessionQueue.AddAsync(sessionQueue);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteActiveAgentSession(ActiveAgentSession session)
        {
            _dbContext.ActiveAgentSessions.Remove(session);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ActiveAgentSession> GetActiveAgentSession(Guid sessionId)
        {
            return await _dbContext.ActiveAgentSessions.SingleOrDefaultAsync(x => x.SessionId == sessionId);
        }

        public async Task<List<Team>> GetActiveTeams()
        {
            var currentTimeHour = Helper.GetDefaultDateTime(DateTime.Now.Hour);

            return await _dbContext.Teams
                         .Include(x => x.Agents)
                            .ThenInclude(x => x.ActiveAgentSessions)
                         .Include(x => x.Agents)
                            .ThenInclude(x => x.Seniority)
                         .Where(x => x.WorkStartHourAt <= currentTimeHour && x.WorkFinishHourAt > currentTimeHour && x.Active)
                         .ToListAsync();
        }

        public async Task<Agent> GetAgentWithCapacity()
        {
            var currentTimeHour = Helper.GetDefaultDateTime(DateTime.Now.Hour);

            var agent = await _dbContext.Agents
                            .Include(x => x.Team)
                            .Include(x => x.ActiveAgentSessions)
                            .Include(x => x.Seniority) //making sure to keep lower seniority agetns busy
                            .Where(x =>
                                x.ActiveAgentSessions.Count < x.Seniority.SeniorityMultiplier &&
                                x.Team.Active &&
                                x.Team.WorkFinishHourAt > currentTimeHour &&
                                x.Team.WorkStartHourAt <= currentTimeHour)
                            .GroupBy(x => x.Seniority.Priority)
                            .OrderBy(x => x.Key)
                            .Select(x=>x.OrderBy(y=>y.ActiveAgentSessions.Count).FirstOrDefault())
                            .FirstOrDefaultAsync();
            return agent;
        }

        public async Task<Team> GetOverflowTeam()
        {
            return await _dbContext.Teams
                         .Include(x => x.Agents)
                            .ThenInclude(x => x.ActiveAgentSessions)
                         .Include(x => x.Agents)
                            .ThenInclude(x => x.Seniority)
                         .SingleOrDefaultAsync(x => x.Name == Constants.OverflowTeamName);

        }

        public async Task<List<SessionQueueItem>> GetOrderedSessionQueue()
        {
            return await _dbContext.SessionQueue.OrderBy(x => x.CreatedAt).ToListAsync();
        }

        public async Task<int> GetSessionQueueCount()
        {
            return await _dbContext.SessionQueue.CountAsync();
        }

        public async Task RemoveFromSessionQueue(SessionQueueItem sessionToRemove)
        {
            _dbContext.SessionQueue.RemoveRange(sessionToRemove);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTeamAsync(Team team)
        {
            _dbContext.Teams.Update(team);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<SessionQueueItem> GetSessionById(Guid sessionId)
        {
            return await _dbContext.SessionQueue.FirstOrDefaultAsync(x => x.Id == sessionId);
        }
    }
}
