using Quartz;
using SessionCoordinatorService.Services;
using Support.Shared.Lib.DTOs;

namespace SessionCoordinatorService.Jobs
{
    public class MonitorSessionsJob : IJob
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISupportRepository _supportRepository;

        public MonitorSessionsJob(IHttpClientFactory httpClientFactory, ISupportRepository supportRepository)
        {
            _httpClientFactory = httpClientFactory;
            _supportRepository = supportRepository;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var agentSessions = await _supportRepository.GetActiveAgentSessionsAsync();
            var sessionQueue = await _supportRepository.GetOrderedSessionQueueAsync();

            if (!agentSessions.Any() && !sessionQueue.Any())
            {
                return;
            }

            var activeConnectionIds = await GetActiveConnectionIds();


            if (!activeConnectionIds.Any()) // if there are no connections, delete all sessions
            {
                if (agentSessions.Any())
                {
                    await _supportRepository.DeleteActiveAgentSessionsAsync(agentSessions);
                }
                if (sessionQueue.Any())
                {
                    await _supportRepository.DeleteFromSessionQueueAsync(sessionQueue);
                }
            }
            else
            {
                var sessionsToDetele = sessionQueue.Where(x => !activeConnectionIds.Contains(x.Id)).ToList();
                if (sessionsToDetele.Any())
                {
                    await _supportRepository.DeleteFromSessionQueueAsync(sessionsToDetele);
                }

                var agentSessionsToDelete = agentSessions.Where(x => !activeConnectionIds.Contains(x.SessionId)).ToList();
                if (agentSessionsToDelete.Any())
                {
                    await _supportRepository.DeleteActiveAgentSessionsAsync(agentSessionsToDelete);
                }
            }
        }

        private async Task<List<Guid>> GetActiveConnectionIds()
        {
            var httpResponseMessage = await _httpClientFactory.CreateClient().GetAsync("https://localhost:7033/api/Connections");

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return new List<Guid>();
            }

            var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();

            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetActiveConnectionsResponse>(jsonString);
            return response?.ActiveConnections ?? new List<Guid>();
        }
    }
}
