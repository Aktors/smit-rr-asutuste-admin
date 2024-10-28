using System.Reflection;
using asutus.api.Extensions;
using asutus.api.Filters;
using asutus.bl.Extensions;
using asutus.common.Configuration;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services.AddControllers(options => 
    options.Filters.Add<DomainExceptionFilter>());
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddSwaggerDocumentation();
builder.Services.AllowCors();

var rabbitMqOptions = builder.Configuration.GetSection("RabbitMQ").Get<RabbitMqOptions>();
if(rabbitMqOptions == null)
    throw new ArgumentException("RabbitMQ configuration is missing");
builder.Services.AddRabbitMqFactory(rabbitMqOptions, factory =>
{
    factory.AutomaticRecoveryEnabled = true; 
});
builder.Services.AddRabbitMqPublisher();


builder.AddPostgresDbStorageImplementation();

builder.Services.AddMediatrResource();

var app = builder.Build();

app.ApplyMigration();
bool.TryParse(Environment.GetEnvironmentVariable("APP_USE_TEST_DATA"), out bool useTestData);
if (useTestData)
    app.ApplySeed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsContainer())
{
    app.UseSwagger();   
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Asutus API V1");
    });
    app.UseCors("AllowAllOrigins");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
