using asutus.common.Model;

namespace asutus.domain.Data.Repositories;

public interface IAsutusRepository
{
    Task AddOrUpdateAsync(AsutusDto asutusDto);
    Task<AsutusDto?> GetAsutusAsync(string asutusDtoCode);
    Task<QueryResultDto<AsutusShortDto>> SearchAsync(AsutusteQueryDto query);
}