using asutus.common.Model;
using asutus.domain.Entities;

namespace asutus.domain.Helpers.Mappers;

public static class AsutusMapper
{
    public static AsutusShortDto MapShortDto(this Asutus entity)
    {
        return new AsutusDto
        {
            Code = entity.Code,
            Name = entity.Name,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate
        };
    }
    
    
    public static AsutusDto Map(this Asutus entity)
    {   
        return new AsutusDto
        {
            Code = entity.Code,
            Name = entity.Name,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            Translations = entity.Translations
                .Select(t => new TranslationDto
                {
                    Code = t.Language.Code,
                    Text = t.Text
                }).ToList()
        };
    }
}