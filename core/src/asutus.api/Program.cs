using System.Reflection;
using asutus.api.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddSwaggerDocumentation();
builder.Services.AllowCors();
builder.Services.AddRabbitMqImplementation();
builder.AddPostgresDbStorageImplementation();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.ApplyMigration();
bool.TryParse(Environment.GetEnvironmentVariable("APP_USE_TEST_DATA"), out bool useTestData);
if (useTestData)
    app.ApplySeed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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
