using asutus.common.Model;

namespace asutus.domain.Data.Repositories;

public interface IAsutusRepository
{
    Task AddOrUpdateAsync(AsutusDto asutusDto, CancellationToken cancellationToken = default);
    Task<AsutusDto?> GetAsutusAsync(string asutusDtoCode, 
        CancellationToken cancellationToken = default);
    Task DeleteByCodeAsync(String asutusCode,
        CancellationToken cancellationToken = default);
    Task<QueryResultDto<AsutusShortDto>> SearchAsync(AsutusteQueryDto query, 
        CancellationToken cancellationToken = default);
    Task<ClassifierDto[]> GetClassifierByGroup(string code,
        CancellationToken cancellationToken = default);
    Task<InformationSystemDto[]> ListInformationSystems(CancellationToken cancellationToken = default);
}