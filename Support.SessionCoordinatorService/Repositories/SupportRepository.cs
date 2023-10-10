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

        public async Task AddActiveAgentSessionAsync(ActiveAgentSession activeAgentSession)
        {
            await _dbContext.ActiveAgentSessions.AddRangeAsync(activeAgentSession);

            await _dbContext.SaveChangesAsync();
        }

        public async Task AddToSessionQueueAsync(SessionQueueItem sessionQueue)
        {
            await _dbContext.SessionQueue.AddAsync(sessionQueue);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteActiveAgentSessionAsync(ActiveAgentSession session)
        {
            _dbContext.ActiveAgentSessions.Remove(session);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ActiveAgentSession> GetActiveAgentSessionAsync(Guid sessionId)
        {
            return await _dbContext.ActiveAgentSessions.SingleOrDefaultAsync(x => x.SessionId == sessionId);
        }

        public async Task<List<Team>> GetActiveTeamsAsync()
        {
            var currentTimeHour = Helper.GetDefaultDateTime(DateTime.Now.Hour);
            var currentTimeHourAtNextDay = currentTimeHour.AddDays(1);

            return await _dbContext.Teams
                         .Include(x => x.Agents)
                            .ThenInclude(x => x.ActiveAgentSessions)
                         .Include(x => x.Agents)
                            .ThenInclude(x => x.Seniority)
                         .Where(x => x.Active &&
                                    (
                                        (x.WorkStartHourAt <= currentTimeHour && x.WorkFinishHourAt > currentTimeHour) ||
                                        (x.WorkStartHourAt <= currentTimeHourAtNextDay && x.WorkFinishHourAt > currentTimeHourAtNextDay)
                                    )
                                )
                         .ToListAsync();
        }

        public async Task<Agent> GetAgentWithCapacityAsync()
        {
            var currentTimeHour = Helper.GetDefaultDateTime(DateTime.Now.Hour);
            var currentTimeHourAtNextDay = currentTimeHour.AddDays(1);

            var agent = await _dbContext.Agents
                            .Include(x => x.Team)
                            .Include(x => x.ActiveAgentSessions)
                            .Include(x => x.Seniority) //making sure to keep lower seniority agetns busy
                            .Where(x => x.ActiveAgentSessions.Count < x.Seniority.SeniorityMultiplier &&
                                       x.Team.Active &&
                                       (
                                           (x.Team.WorkStartHourAt <= currentTimeHour && x.Team.WorkFinishHourAt > currentTimeHour) ||
                                           (x.Team.WorkStartHourAt <= currentTimeHourAtNextDay && x.Team.WorkFinishHourAt > currentTimeHourAtNextDay)
                                       )
                                   )
                            .GroupBy(x => x.Seniority.Priority)
                            .OrderBy(x => x.Key)
                            .Select(x => x.OrderBy(y => y.ActiveAgentSessions.Count).FirstOrDefault())
                            .FirstOrDefaultAsync();
            return agent;
        }

        public async Task<Team> GetOverflowTeamAsync()
        {
            return await _dbContext.Teams
                         .Include(x => x.Agents)
                            .ThenInclude(x => x.ActiveAgentSessions)
                         .Include(x => x.Agents)
                            .ThenInclude(x => x.Seniority)
                         .SingleOrDefaultAsync(x => x.Name == Constants.OverflowTeamName);

        }

        public async Task<List<SessionQueueItem>> GetOrderedSessionQueueAsync()
        {
            return await _dbContext.SessionQueue.OrderBy(x => x.CreatedAt).ToListAsync();
        }

        public async Task<int> GetSessionQueueCountAsync()
        {
            return await _dbContext.SessionQueue.CountAsync();
        }

        public async Task DeleteFromSessionQueueAsync(SessionQueueItem sessionToRemove)
        {
            _dbContext.SessionQueue.RemoveRange(sessionToRemove);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTeamAsync(Team team)
        {
            _dbContext.Teams.Update(team);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<SessionQueueItem> GetSessionByIdAsync(Guid sessionId)
        {
            return await _dbContext.SessionQueue.FirstOrDefaultAsync(x => x.Id == sessionId);
        }

        public async Task DeleteActiveAgentSessionsAsync(List<ActiveAgentSession> agentSessions)
        {
            _dbContext.ActiveAgentSessions.RemoveRange(agentSessions);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFromSessionQueueAsync(List<SessionQueueItem> sessionsToRemove)
        {
            _dbContext.SessionQueue.RemoveRange(sessionsToRemove);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ActiveAgentSession>> GetActiveAgentSessionsAsync()
        {
            return await _dbContext.ActiveAgentSessions.ToListAsync();
        }
    }
}
