using Microsoft.EntityFrameworkCore.Storage;
using Shared.Library.EventBus.Abstractions;
using Shared.Library.EventBus.Events;
using Shared.Library.Entities;
using Shared.Library.Extensions;

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

        public async Task<bool> RemoveSession(Guid sessionId)
        {
            try
            {
                var agentSession = await _supportRepository.GetActiveAgentSession(sessionId);
                if (agentSession != null)
                {
                    await _supportRepository.DeleteActiveAgentSession(agentSession);
                }

                var session = await _supportRepository.GetSessionById(sessionId);
                if (session != null)
                {
                    await _supportRepository.RemoveFromSessionQueue(session);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task DeactivateOverflowTeam()//called 1 per day via quatrz
        {
            var overflowTeam = await _supportRepository.GetOverflowTeam();
            if (overflowTeam.Active)
            {
                overflowTeam.Active = false;
                await _supportRepository.UpdateTeamAsync(overflowTeam);
            }
        }

        public async Task<bool> AppendToAgent()
        {
            IDbContextTransaction transaction = null;

            try
            {
                var sessions = await _supportRepository.GetOrderedSessionQueue();
                if (!sessions.Any())
                {
                    return true; //in this case the sessions have been already assigned (may be by another instance) so we are respoding with true to "ack" the rabbitMQ message
                }

                foreach (var session in sessions)
                {
                    transaction = await _tranasctionProviderRepository.BeginTransaction();

                    var agent = await _supportRepository.GetAgentWithCapacity();

                    if (agent == null)
                    {
                        break;
                    }

                    await _supportRepository.AddActiveAgentSession(new ActiveAgentSession { AgentId = agent.Id, SessionId = session.Id, Id = Guid.NewGuid() });
                    await _supportRepository.RemoveFromSessionQueue(session);
                    
                    await _tranasctionProviderRepository.CommitTransaction(transaction);

                }

                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    await _tranasctionProviderRepository.RollbackTransaction(transaction);
                }

                _logger.LogError(ex.Message, ex);

                return false;
            }
            finally
            {
                if (transaction != null)
                {
                    await _tranasctionProviderRepository.DisposeTransaction(transaction);
                }
            }
        }

        public async Task<Guid?> GenerateSession()
        {
            var activeTeams = await _supportRepository.GetActiveTeams();
            int queueLength = await _supportRepository.GetSessionQueueCount();

            if (!CanBeQueued(GetTeamCapacity(activeTeams), queueLength))//max queue capacity reached
            {
                var overflowTeam = activeTeams.SingleOrDefault(x => x.Name == Constants.OverflowTeamName);
                if (overflowTeam != null) //overflow is already active, nothing else is possible to do
                {
                    return null;
                }

                overflowTeam = await _supportRepository.GetOverflowTeam();

                if (overflowTeam == null) //overflow team doesn't exist in db
                {
                    return null;
                }

                var currentTimeHour = Helper.GetDefaultDateTime(DateTime.Now.Hour);
                var currentTimeHourAtNextDay = currentTimeHour.AddDays(1);

                if ((overflowTeam.WorkStartHourAt <= currentTimeHour && overflowTeam.WorkFinishHourAt > currentTimeHour) ||
                    (overflowTeam.WorkStartHourAt <= currentTimeHourAtNextDay && overflowTeam.WorkFinishHourAt > currentTimeHourAtNextDay)) //overflow team can be activated
                {
                    await ActivateTeam(overflowTeam);

                    activeTeams = await _supportRepository.GetActiveTeams(); //refreshing in case if other instances already occupied overflow agents
                    queueLength = await _supportRepository.GetSessionQueueCount();

                    if (!CanBeQueued(GetTeamCapacity(activeTeams), queueLength))//other instances already occupied overflow agents
                    {
                        return null;
                    }

                    return await GenerateSessionAndNotify();
                }

                return null; //overflow team can't be activated
            }

            return await GenerateSessionAndNotify();
        }

        private bool CanBeQueued(int teamCapacity, int queueLength)
        {
            return queueLength < teamCapacity * 1.5;
        }

        private async Task ActivateTeam(Team overflowTeam)
        {
            overflowTeam.Active = true;

            await _supportRepository.UpdateTeamAsync(overflowTeam);
        }

        private int GetTeamCapacity(List<Team> teams)
        {
            var agents = new List<Agent>();
            foreach (var team in teams)
            {
                agents.AddRange(team.Agents);
            }

            return agents.Select(x => x.Seniority).Select(x => x.SeniorityMultiplier).Sum();
        }

        private async Task<Guid> GenerateSessionAndNotify()
        {
            var sessionId = Guid.NewGuid();

            await _supportRepository.AddToSessionQueue(new SessionQueueItem { CreatedAt = DateTime.Now, Id = sessionId });

            _eventBus.Publish(new SessionGeneratedEvent { SessionId = sessionId });

            return sessionId;
        }
    }
}
