using Microsoft.EntityFrameworkCore;
using Quartz;
using Shared.Library.EventBus.Abstractions;
using Shared.Library.EventBus.Events;
using Shared.Library.EventBus.RabbitMQ.Extensions;
using Shared.Library.Entities;
using SessionCoordinatorService.Handlers;
using SessionCoordinatorService.Options;
using SessionCoordinatorService.Repositories;
using SessionCoordinatorService.Services;
using SessionCoordinatorService.Jobs;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration
 .SetBasePath(System.IO.Directory.GetCurrentDirectory())
 .AddJsonFile($"appsettings.json", optional: false)
 .AddEnvironmentVariables()
 .Build();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<SupportDbContext>(options =>
{
    options.UseSqlServer(configuration.GetSection("DatabaseUrl").Value, x=>x.MigrationsAssembly("SessionCoordinatorService"));
});

builder.Services.AddEventBus(
    new EventBusRabbitMQOptions
    {
        EventBusRetryCount = configuration.GetSection("RabbitMQRetryCount").Get<int>(),
        HostName = configuration.GetSection("RabbitMQConnection").Value
    }
);

builder.Services.AddTransient<IIntegrationEventHandler<AppendSessionsToAgentEvent>, AppendSessionsToAgentEventHandler>();
builder.Services.AddTransient<IIntegrationEventHandler<SessionCancelledEvent>, SessionCancelledEventHandler>();
builder.Services.AddTransient<ISupportRepository, SupportRepository>();
builder.Services.AddTransient<ITranasctionProviderRepository, TranasctionProviderRepository>();
builder.Services.AddTransient<SessionManagementService>();
builder.Services.AddTransient<ResetOverflowJob>();

builder.Services.Configure<MessageBusOptions>(
    builder.Configuration.GetSection("MessageBusOptions"));

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();

    var jobKey = new JobKey("ResetOverflow");
    q.AddJob<ResetOverflowJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("ResetOverflow-trigger")
        .WithDailyTimeIntervalSchedule
         (s =>
            s.WithIntervalInHours(24)
           .OnEveryDay()
           .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(
               configuration.GetSection("SessionCoordinatorOptions").GetSection("OfficeHourEnd").Get<int>(),
               00
            ))
         ));


    var sessionMonitorJob = new JobKey("MonitorSessions");
    q.AddJob<MonitorSessionsJob>(opts => opts.WithIdentity(sessionMonitorJob));
    q.AddTrigger(opts => opts
        .ForJob(sessionMonitorJob)
        .WithIdentity("MonitorSessions-trigger")
        .WithCronSchedule("*/10 * * * * ?"));
});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

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

app.UseEventBus(eventBus =>
{
    eventBus.Subscribe<AppendSessionsToAgentEvent, IIntegrationEventHandler<AppendSessionsToAgentEvent>>();
    eventBus.Subscribe<SessionCancelledEvent, IIntegrationEventHandler<SessionCancelledEvent>>();
});

app.Run();