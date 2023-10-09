namespace SessionCoordinatorService.Options
{
    public class MessageBusOptions
    {
        public string RabbitMQConnection { get; set; }
        public int RabbitMQRetryCount { get; set; }
    }
}
