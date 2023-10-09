using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Quartz;
using Shared.Library.Entities;

namespace Monitor.Jobs
{
    public class MonitorSessions : IJob
    {
        private readonly ConnectionService _sessionService;
        private readonly SupportDbContext _supportDbContext;

        public MonitorSessions(ConnectionService sessionService, SupportDbContext supportDbContext)
        {
            _sessionService = sessionService;
            _supportDbContext = supportDbContext;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var activeConnections = await _sessionService.sessionCollection.Find(x => x.ExpireAt > DateTime.UtcNow).ToListAsync();

            var sessionsToDetele = await _supportDbContext.SessionQueue.Where(x => !activeConnections.Select(y => y.Id).Contains(x.Id)).ToListAsync();
            if(sessionsToDetele.Any())
            {
                _supportDbContext.SessionQueue.RemoveRange(sessionsToDetele);
            }

            var agentSessionsToDelete = await _supportDbContext.ActiveAgentSessions.Where(x => !activeConnections.Select(y => y.Id).Contains(x.SessionId)).ToListAsync();
            if (agentSessionsToDelete.Any())
            {
                _supportDbContext.ActiveAgentSessions.RemoveRange(agentSessionsToDelete);
            }

            await _supportDbContext.SaveChangesAsync();
        }
    }
}
