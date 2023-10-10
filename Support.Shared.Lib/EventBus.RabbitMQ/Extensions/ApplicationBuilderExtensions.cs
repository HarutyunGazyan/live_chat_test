using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shared.Library.EventBus.Abstractions;

namespace Shared.Library.EventBus.RabbitMQ.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseEventBus(this IApplicationBuilder app, Action<IEventBus> evtBus)
        {
            IEventBus eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            evtBus?.Invoke(eventBus);
            return app;
        }
    }
}
