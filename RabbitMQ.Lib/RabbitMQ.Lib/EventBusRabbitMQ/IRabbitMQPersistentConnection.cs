using RabbitMQ.Client;

namespace RabbitMQ.Lib.EventBusRabbitMQ
{

    public interface IRabbitMQPersistentConnection
        : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
