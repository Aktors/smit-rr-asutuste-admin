
namespace asutus.api.Extensions;

public static class EnvironmentEnvExtensions
{
    public static bool IsContainer(this IHostEnvironment hostEnvironment)
    {
        return hostEnvironment.IsEnvironment("Container");
    }

}