using asutus.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asutus.domain.Data.Configurations;

public class AsutusConfiguration : IEntityTypeConfiguration<Asutus>
{
    public void Configure(EntityTypeBuilder<Asutus> builder)
    {
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder.HasIndex(a => a.Code)
            .IsUnique();

        builder.HasMany(a => a.Translations)
            .WithOne(t => t.Asutus)
            .HasForeignKey(t => t.AsutusId);
    }
}