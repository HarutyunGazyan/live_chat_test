using Microsoft.EntityFrameworkCore;
using Monitor;
using Monitor.Jobs;
using Quartz;
using Shared.Library.Entities;
using Shared.Library.EventBus.RabbitMQ.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration
 .SetBasePath(System.IO.Directory.GetCurrentDirectory())
 .AddJsonFile($"appsettings.json", optional: false)
 .AddEnvironmentVariables()
 .Build();

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    var connectionMonitorJob = new JobKey("MonitorConnections");
    q.AddJob<MonitorConnections>(opts => opts.WithIdentity(connectionMonitorJob));
    q.AddTrigger(opts => opts
        .ForJob(connectionMonitorJob)
        .WithIdentity("MonitorConnections-trigger")
        .WithCronSchedule("* * * * * ?"));


    var sessionMonitorJob = new JobKey("MonitorSessions");
    q.AddJob<MonitorSessions>(opts => opts.WithIdentity(sessionMonitorJob));
    q.AddTrigger(opts => opts
        .ForJob(sessionMonitorJob)
        .WithIdentity("MonitorSessions-trigger")
        .WithCronSchedule("*/10 * * * * ?"));
});

builder.Services.AddDbContext<SupportDbContext>(options =>
{
    options.UseSqlServer(configuration.GetSection("DatabaseUrl").Value);
});

builder.Services.AddSingleton<ConnectionService>();

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

builder.Services.AddEventBus(
    new EventBusRabbitMQOptions
    {
        EventBusRetryCount = configuration.GetSection("RabbitMQRetryCount").Get<int>(),
        HostName = configuration.GetSection("RabbitMQConnection").Value
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.Run();
