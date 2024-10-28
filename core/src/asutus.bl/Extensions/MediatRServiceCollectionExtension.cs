using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace asutus.bl.Extensions;

public static class MediatRServiceCollectionExtension
{
    public static void AddMediatrResource(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}