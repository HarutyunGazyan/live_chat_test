using Microsoft.EntityFrameworkCore;
using RabbitMQ.Lib.EventBus.Abstractions;
using RabbitMQ.Lib.EventBus.Events;
using RabbitMQ.Lib.EventBus.RabbitMQ.Extensions;
using SessionCoordinatorService.Entities;
using SessionCoordinatorService.Handlers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration
 .SetBasePath(System.IO.Directory.GetCurrentDirectory())
 .AddJsonFile($"appsettings.json", optional: false)
 .AddEnvironmentVariables()
 .Build();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SupportDbContext>(options =>
{
    options.UseSqlServer(configuration.GetSection("DatabaseUrl").Value);
});

builder.Services.AddEventBus(
    new EventBusRabbitMQOptions
    {
        EventBusRetryCount = configuration.GetSection("RabbitMQRetryCount").Get<int>(),
        HostName = configuration.GetSection("RabbitMQConnection").Value
    }
);

builder.Services.AddTransient<IIntegrationEventHandler<AppendSessionToAgentEvent>, AppendSessionToAgentEventHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



try
{
    app.UseEventBus(eventBus =>
    {
        eventBus.Subscribe<AppendSessionToAgentEvent, IIntegrationEventHandler<AppendSessionToAgentEvent>>();
        eventBus.Publish(new AppendSessionToAgentEvent());
    });
}
catch (Exception ex)
{

}

app.Run();