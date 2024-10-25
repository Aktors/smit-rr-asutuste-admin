using asutus.domain.Data;
using Microsoft.EntityFrameworkCore;

namespace asutus.api.Extensions;

public static class WebApplicationExtensions
{
  public static void ApplyMigration(this WebApplication app)
  {
    using (var scope = app.Services.CreateScope())
    {
      var dbContext = scope.ServiceProvider.GetRequiredService<AsutusContext>();
      dbContext.Database.Migrate();
    }
  }

  public static void ApplySeed(this WebApplication app)
  {
    using (var scope = app.Services.CreateScope())
    {
      var context = scope.ServiceProvider.GetRequiredService<AsutusContext>();
      AsutusTestData.Seed(context);
    }
  }
}