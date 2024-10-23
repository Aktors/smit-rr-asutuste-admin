using asutus.api.Model;
using asutus.common.Model;

namespace asutus.api.Helpers;

public static class ReplicationLogQueryMapper
{
    public static ReplicationLogQueryDto Map(this ReplicationLogQuery query)
    {
        return new ReplicationLogQueryDto
        {
            Pagination = new Pagination
            {
                Page = query.Page ?? 1,
                PageSize = query.PageSize ?? 10,
                SortBy = query.SortBy ?? nameof(AsutusteQuery.Code),
                SortOrder = query.SortOrder ?? "asc"
            }
        };
    }
}