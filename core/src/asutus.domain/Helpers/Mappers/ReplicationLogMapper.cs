using asutus.common.Model;
using asutus.domain.Entities;

namespace asutus.domain.Helpers.Mappers;

public static class ReplicationLogMapper
{
    public static ReplicationLogDto Map(this MessageLog entity)
    {   
        return new ReplicationLogDto
        {
            ReferenceId = entity.ReferenceId,
            Caption = entity.Caption,
            SentDate = entity.SentDate,
            Content = entity.Caption
        };
    }
}