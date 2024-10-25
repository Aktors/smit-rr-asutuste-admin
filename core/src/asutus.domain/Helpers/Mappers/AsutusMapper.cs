using asutus.common.Model;
using asutus.domain.Entities;

namespace asutus.domain.Helpers.Mappers;

public static class AsutusMapper
{
    public static Asutus Map(this AsutusDto dto)
    {
        return new Asutus
        {
            Code = dto.Code,
            Name = dto.Name
            //TODO: Add mapper logic with messages
        };
    }

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
            EndDate = entity.EndDate
        };
    }
}