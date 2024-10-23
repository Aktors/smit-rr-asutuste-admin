using asutus.api.Model;
using asutus.common.Model;

namespace asutus.api.Helpers;

public static class AsutusteQueryMapper
{
    public static AsutusteQueryDto Map(this AsutusteQuery query)
    {
        return new AsutusteQueryDto
        {
            Code = query.Code,
            Name = query.Name,
            StartDate =  query.StartDate,
            EndDate =  query.EndDate,
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