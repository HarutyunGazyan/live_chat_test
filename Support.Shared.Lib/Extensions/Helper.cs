namespace Shared.Library.Extensions
{
    public static class Helper
    {
        public static DateTime GetDefaultDateTime(int hour)
        {
            return new DateTime(1, 1, 1, hour, 1, 1, 0, DateTimeKind.Unspecified);
        }
    }
}
