using System.Reflection;
using System.Runtime.CompilerServices;
using asutus.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace asutus.domain.Data;

public class AsutusContext: DbContext
{
    public DbSet<Asutus> Asutused { get; set; }
    public DbSet<Translation> Translations { get; set; }
    public DbSet<InformationSystem> InformationSystems { get; set; }
    public DbSet<SystemInstance> SystemInstances { get; set; }
    public DbSet<Classifier> Classifiers { get; set; }
    
    public DbSet<MessageLog> MessageLogs { get; set; }
    
    public AsutusContext(DbContextOptions<AsutusContext> options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

public static class AsutusContextInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}
