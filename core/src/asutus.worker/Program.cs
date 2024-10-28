using asutus.bl.Extensions;
using asutus.bl.Services;
using asutus.common.Configuration;
using asutus.domain.Data.Repositories;
using asutus.worker;
using asutus.worker.Extensions;
using asutus.worker.services;

var builder = Host.CreateApplicationBuilder(args);
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services.AddHostedService<Worker>();

var rabbitMqOptions = builder.Configuration.GetSection("RabbitMQ").Get<RabbitMqOptions>();
if(rabbitMqOptions == null)
    throw new ArgumentException("RabbitMQ configuration is missing");
builder.Services.AddRabbitMqFactory(rabbitMqOptions, factory =>
{
    factory.AutomaticRecoveryEnabled = true; 
});
builder.Services.AddSingleton<IMessageLogService, DbMessageLogService>();
builder.Services.AddSingleton<IMessageListener, RabbitMqListener>();
builder.Services.AddSingleton<IMessageLogRepository, MessageLogRepository>();
builder.Services.AddSingleton<IInformationSystemRepository, InformationSystemRepository>();

builder.AddPostgresDbStorageImplementation();

var host = builder.Build();
host.Run();