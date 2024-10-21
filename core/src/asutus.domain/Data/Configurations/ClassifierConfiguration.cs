using asutus.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asutus.domain.Data.Configurations;

public class ClassifierConfiguration : IEntityTypeConfiguration<Classifier>
{
    public void Configure(EntityTypeBuilder<Classifier> builder)
    {
        builder.HasIndex(c => c.Code)
            .IsUnique();
    }
}