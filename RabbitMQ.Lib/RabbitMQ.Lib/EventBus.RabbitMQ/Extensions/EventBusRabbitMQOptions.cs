﻿namespace RabbitMQ.Lib.EventBus.RabbitMQ.Extensions
{
    public class EventBusRabbitMQOptions
    {
        public string HostName { get; set; } 
        
        public int EventBusRetryCount { get; set; }
    }
}
