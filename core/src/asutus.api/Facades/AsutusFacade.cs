using asutus.api.Helpers;
using asutus.api.Model;
using asutus.api.services;
using asutus.common.Model;
using asutus.domain.Data.Repositories;

namespace asutus.api.Facades;

public class AsutusFacade
{
    private readonly IReplicationService _replicationService;
    private readonly IAsutusRepository _asutusRepository;
    
    public AsutusFacade(
        IReplicationService replicationService,
        IAsutusRepository asutusRepository)
    {
        _replicationService = replicationService;
        _asutusRepository = asutusRepository;
    }

    public async Task UpdateRecord(AsutusDto asutusDto, ReplicationDto[] replicationDtos)
    {
       await _asutusRepository.AddOrUpdateAsync(asutusDto);
       var updatedAsutus = await _asutusRepository.GetAsutusAsync(asutusDto.Code);
       await _replicationService.Replicate(updatedAsutus, replicationDtos);
    }

    public async Task<QueryResultDto<AsutusShortDto>> SearchAsync(AsutusteQuery query)
    {
        return await _asutusRepository.SearchAsync(query.Map());
    }

    public async Task<AsutusDto?> SearchByCodeAsync(string code)
    {
        return await _asutusRepository.GetAsutusAsync(code);
    }
}