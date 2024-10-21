using asutus.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asutus.domain.Data.Configurations;

public class InformationSystemConfiguration : IEntityTypeConfiguration<InformationSystem>
{
    public void Configure(EntityTypeBuilder<InformationSystem> builder)
    {
        builder.HasIndex(isys => isys.Code)
            .IsUnique();

        builder.HasMany(isys => isys.SystemInstances)
            .WithOne(si => si.InformationSystem)
            .HasForeignKey(si => si.InformationSystemId);
    }
}