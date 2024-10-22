using asutus.common.Model;
using asutus.domain.Entities;

namespace asutus.domain.Helpers.Mappers;

//TODO: Add mapper logic 
public static class AsutusMapper
{
    public static Asutus Map(this AsutusDto dto)
    {
        return new Asutus
        {
            Code = dto.Code,
            Name = dto.Name
        };
    }

    public static AsutusDto Map(this Asutus entity)
    {
        return new AsutusDto
        {
            Code = entity.Code,
            Name = entity.Name
        };
    }
}