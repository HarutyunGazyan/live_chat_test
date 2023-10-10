using Microsoft.Extensions.Options;
using Monitor.Jobs;
using Quartz;
using Shared.Library.EventBus.RabbitMQ.Extensions;
using Shared.Library.Services;
using Support.Shared.Lib.Options;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration
 .SetBasePath(System.IO.Directory.GetCurrentDirectory())
 .AddJsonFile($"appsettings.json", optional: false)
 .AddEnvironmentVariables()
 .Build();

builder.Services.AddControllersWithViews(); 

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    var connectionMonitorJob = new JobKey("MonitorConnections");
    q.AddJob<MonitorConnectionsJob>(opts => opts.WithIdentity(connectionMonitorJob));
    q.AddTrigger(opts => opts
        .ForJob(connectionMonitorJob)
        .WithIdentity("MonitorConnections-trigger")
        .WithCronSchedule("* * * * * ?"));
});

builder.Services.Configure<MongoDbOptions>(configuration.GetSection("MongoDbOptions"));
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

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

