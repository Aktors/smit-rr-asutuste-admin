using asutus.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asutus.domain.Data.Configurations;

public class TranslationConfiguration : IEntityTypeConfiguration<Translation>
{
    public void Configure(EntityTypeBuilder<Translation> builder)
    {
        builder.HasOne(t => t.Language)
            .WithMany()
            .HasForeignKey(t => t.LanguageId);
        
        builder.HasOne(t => t.Asutus)
            .WithMany(a => a.Translations)
            .HasForeignKey(t => t.AsutusId);
    }
}