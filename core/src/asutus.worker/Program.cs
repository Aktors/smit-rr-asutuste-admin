using System.Reflection;
using asutus.bl.Commands;
using asutus.bl.Extensions;
using asutus.bl.Handlers;
using asutus.bl.Services;
using asutus.common.Configuration;
using asutus.domain.Data.Repositories;
using asutus.worker;
using asutus.worker.Extensions;
using asutus.worker.services;
using MediatR;

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
builder.Services.AddScoped<IMessageLogService, DbMessageLogService>();
builder.Services.AddSingleton<IMessageListener, RabbitMqListener>();
builder.Services.AddScoped<IMessageLogRepository, MessageLogRepository>();
builder.Services.AddScoped<IInformationSystemRepository, InformationSystemRepository>();

builder.Services.AddMediatR(cfg=> cfg.RegisterServicesFromAssemblies(    Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<IRequestHandler<ConfirmReplicationLogRequest, Unit>, ConfirmReplicationLogHandler>();

builder.AddPostgresDbStorageImplementation();

var host = builder.Build();
host.Run();