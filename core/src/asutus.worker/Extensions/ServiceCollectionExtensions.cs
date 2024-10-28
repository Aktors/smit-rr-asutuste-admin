using asutus.domain.Data;
using asutus.domain.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace asutus.worker.Extensions;

public static class ServiceCollectionExtensions
{
    
    public static void AddPostgresDbStorageImplementation(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AsutusContext>(options => {
            options.UseNpgsql(builder.Configuration.GetConnectionString("AsutusConnection"));
        });
        builder.Services.AddScoped<IMessageLogRepository, MessageLogRepository>();
        builder.Services.AddScoped<IAsutusRepository, AsutusRepository>();
    }
}