using RabbitMQ.Client;

namespace RabbitMQ.Lib.EventBus.RabbitMQ
{
    public interface IRabbitMQPersistentConnection:IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
