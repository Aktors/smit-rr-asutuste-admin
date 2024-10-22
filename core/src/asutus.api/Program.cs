using asutus.api.Facades;
using asutus.api.services;
using asutus.api.services.rabbitMq;
using asutus.domain.Data;
using asutus.domain.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS
builder.Services.AddCors(options =>
{
    //TODO: configuring env properly
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

//TODO: fix scopes
//MQ
builder.Services.AddRabbitMqConfiguration();
builder.Services.AddScoped<IReplicationService, ReplicationService>();
builder.Services.AddScoped<IMessagePublisherService, RabbitMqPublisherService>();
builder.Services.AddScoped<IMessageListener, RabbitMqListener>();
builder.Services.AddScoped<IMessageLogService, DbMessageLogService>();

builder.Services.AddScoped<AsutusFacade>();

//Database
builder.Services.AddDbContext<AsutusContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("AsutusConnection"));
});
builder.Services.AddScoped<IMessageLogRepository, DbMessageLogRepository>();
builder.Services.AddScoped<IAsutusRepository, DbAsutusRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AsutusContext>();
    dbContext.Database.Migrate();
}

//seed
var useTestData = builder.Configuration.GetValue<bool>("UseTestData");
if (useTestData)
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<AsutusContext>();
        AsutusTestData.Seed(context);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAllOrigins");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();