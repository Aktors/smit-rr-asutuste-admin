using asutus.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asutus.domain.Data.Configurations;

public class MessageLogConfiguration : IEntityTypeConfiguration<MessageLog>
{
    public void Configure(EntityTypeBuilder<MessageLog> builder)
    {
        builder.HasKey(ml => ml.Id);
        builder.Property(ml => ml.Id).ValueGeneratedOnAdd();
        
        builder.Property(ml => ml.ReferenceId)
            .IsRequired();
        builder.HasIndex(ml => ml.ReferenceId)
            .IsUnique();

        builder.Property(ml => ml.Caption)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(ml => ml.Content)
            .HasColumnType("jsonb");

        builder.Property(ml => ml.SentDate);
    }
}