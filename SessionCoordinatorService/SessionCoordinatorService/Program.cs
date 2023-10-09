using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Lib.EventBus.Abstractions;
using RabbitMQ.Lib.EventBus.Events;
using RabbitMQ.Lib.EventBusRabbitMQ;
using SessionCoordinatorService.Entities;

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

builder.Services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
{
    var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();
    var factory = new ConnectionFactory()
    {
        HostName = configuration.GetSection("RabbitMQConnection").Value
    };

    return new DefaultRabbitMQPersistentConnection(factory, logger);
});

builder.Services.AddSingleton<IEventBus, EventBusRabbitMQ>();

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

var eventBus = app.Services.GetRequiredService<IEventBus>();
try
{
    eventBus.Publish(new CreateSessionRequestEvent());
}
catch (Exception ex)
{

}

app.Run();