using SessionCoordinatorService.Entities;

namespace SessionCoordinatorService.Services.DTOs
{
    public class OverflowInfo
    {
        public bool IsAvailable { get; set; }
        public Team OverflowTeam { get; set; }
    }
}
