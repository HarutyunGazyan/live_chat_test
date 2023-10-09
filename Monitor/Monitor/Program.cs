using Monitor;
using Monitor.Jobs;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    var jobKey = new JobKey("Monitor");
    q.AddJob<MonitorSessions>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("Monitor-trigger")
        .WithCronSchedule("* * * * * ?"));

});
builder.Services.AddSingleton<SessionService>();

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.Run();
