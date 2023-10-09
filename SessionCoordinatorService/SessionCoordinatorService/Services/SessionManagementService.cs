using RabbitMQ.Lib.EventBus.Abstractions;
using RabbitMQ.Lib.EventBus.Events;
using SessionCoordinatorService.Entities;
using SessionCoordinatorService.Services.DTOs;

namespace SessionCoordinatorService.Services
{
    public class SessionManagementService
    {
        private readonly ILogger<SessionManagementService> _logger;
        private readonly ISupportRepository _supportRepository;
        private readonly IEventBus _eventBus;
        private readonly ITranasctionProviderRepository _tranasctionProviderRepository;

        public SessionManagementService(ILogger<SessionManagementService> logger, ISupportRepository supportRepository, IEventBus eventBus, ITranasctionProviderRepository tranasctionProviderRepository)
        {
            _logger = logger;
            _supportRepository = supportRepository;
            _eventBus = eventBus;
            _tranasctionProviderRepository = tranasctionProviderRepository;
        }

        public async Task<bool> AppendToAgent()
        {
            var transaction = await _tranasctionProviderRepository.BeginTransaction();

            try
            {
                var agentsWithCapacity = await _supportRepository.GetAgentsWithCapacity();

                if (!agentsWithCapacity.Any())
                {
                    return false; //in this case there are no free agent yet, so task is not yet complete
                }

                var sessions = await _supportRepository.GetSessionQueue();
                if (!agentsWithCapacity.Any())
                {
                    return true; //in this case the sessions have been already assigned (may be by another instance) so we are respoding with true to "ack" the rabbitMQ message
                }

                var lowerCount = agentsWithCapacity.Count > sessions.Count ? sessions.Count : agentsWithCapacity.Count;

                var activeAgentSessions = new List<ActiveAgentSession>();

                var sessionsToRemove = new List<SessionQueueItem>();

                for (int i = 0; i < lowerCount; i++)
                {
                    activeAgentSessions.Add(new ActiveAgentSession
                    {
                        Id = Guid.NewGuid(),
                        SessionId = sessions[i].Id,
                        AgentId = agentsWithCapacity[i].Id
                    });
                    sessionsToRemove.Add(sessions[i]);
                }

                await _supportRepository.AddActiveAgentSessions(activeAgentSessions);
                await _supportRepository.RemoveFromSessionsQueue(sessionsToRemove);

                await _tranasctionProviderRepository.CommitTransaction(transaction);

                return true;
            }
            catch (Exception ex)
            {
                await _tranasctionProviderRepository.RollbackTransaction(transaction);

                _logger.LogError(ex.Message, ex);

                return false;
            }
            finally
            {
                await _tranasctionProviderRepository.DisposeTransaction(transaction);
            }
        }

        public async Task<Guid?> GenerateSession(Guid sessionId)
        {
            var team = await _supportRepository.GetActiveTeam();
            var teamCapacity = GetTeamCapacity(team);
            int queueLength = await GetSessionQueueLength();

            if (queueLength > teamCapacity * 1.5)
            {
                var overflowInfo = await GetOverflowInfo();
                if (overflowInfo.IsAvailable)
                {
                    var overflowTeam = overflowInfo.OverflowTeam;

                    if (!overflowTeam.Active)
                    {
                        await ActivateTeam(overflowTeam);
                    } //MAY BE OVERFLOW TEAM CAPACITY SHOULD BE ADDED TO THE MAIN TEAM CAPACITY, ASK TASK CREATORS

                    if (!HasAvailableAgent(overflowTeam))
                    {
                        return null;
                    }

                    return await GenerateAndPublishSession();
                }

                return null;
            }

            return await GenerateAndPublishSession();
        }

        private async Task<int> GetSessionQueueLength()
        {
            return await _supportRepository.GetSessionQueueCount();
        }

        private async Task ActivateTeam(Team overflowTeam)
        {
            overflowTeam.Active = true;

            await _supportRepository.UpdateAsync(overflowTeam);
        }

        private bool HasAvailableAgent(Team team)
        {
            return team.Agents.Any(x => x.ActiveAgentSessions.Count < x.Seniority.SeniorityMultiplier);
        }

        private async Task<Team> GetActiveTeam()
        {
            return await _supportRepository.GetActiveTeam();
        }

        private int GetTeamCapacity(Team team)
        {
            return team.Agents.Select(x => x.Seniority).Select(x => x.SeniorityMultiplier).Sum();
        }

        private async Task<OverflowInfo> GetOverflowInfo()
        {
            var result = new OverflowInfo { IsAvailable = false };

            var timeHour = DateTime.Now.Hour;

            if (timeHour > 10 && timeHour < 18)
            {
                result.OverflowTeam = await _supportRepository.GetOverflowTeam();
                result.IsAvailable = true;
            }

            return result;
        }

        private async Task<Guid> GenerateAndPublishSession()
        {
            var sessionId = Guid.NewGuid();

            await _supportRepository.AddToSessionQueue(new SessionQueueItem { CreatedAt = DateTime.Now, Id = sessionId });

            _eventBus.Publish(new MonitorSessionQueueEvent { SessionId = sessionId });

            return sessionId;
        }
    }
}
