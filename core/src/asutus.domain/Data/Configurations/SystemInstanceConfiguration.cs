using asutus.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asutus.domain.Data.Configurations;

public class SystemInstanceConfiguration : IEntityTypeConfiguration<SystemInstance>
{
    public void Configure(EntityTypeBuilder<SystemInstance> builder)
    {
        builder.HasOne(si => si.InformationSystem)
            .WithMany(i => i.SystemInstances)
            .HasForeignKey(si => si.InformationSystemId);

        builder.HasOne(si => si.InstanceType)
            .WithMany()
            .HasForeignKey(si => si.InstanceTypeId);
    }
}