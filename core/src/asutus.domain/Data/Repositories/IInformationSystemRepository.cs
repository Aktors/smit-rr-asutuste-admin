using asutus.common.Model;

namespace asutus.domain.Data.Repositories;

public interface IInformationSystemRepository
{
    Task<InformationSystemDto[]> ListInformationSystems(CancellationToken cancellationToken = default);
}