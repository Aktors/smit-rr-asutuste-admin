using asutus.api.Commands;
using asutus.common.Model;
using asutus.domain.Data.Repositories;
using MediatR;

namespace asutus.api.Handlers;

public class ClassifierByGroupHandler:  IRequestHandler<ClassifierByGroupRequest, ClassifierDto[]>
{    
    private readonly IAsutusRepository _asutusRepository;

    public ClassifierByGroupHandler(IAsutusRepository asutusRepository)
    {
        _asutusRepository = asutusRepository;
    }

    public async Task<ClassifierDto[]> Handle(ClassifierByGroupRequest request, CancellationToken cancellationToken)
    {
        return await _asutusRepository.GetClassifierByGroup(request.Code, cancellationToken);
    }
}