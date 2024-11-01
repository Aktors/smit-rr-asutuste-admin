﻿using asutus.bl.Commands;
using asutus.common.Model;
using asutus.domain.Data.Repositories;
using MediatR;

namespace asutus.bl.Handlers;

public class AsutusteLoeteluHandler : IRequestHandler<AsutusteLoeteluRequest, QueryResultDto<AsutusShortDto>>
{
    private readonly IAsutusRepository _asutusRepository;

    public AsutusteLoeteluHandler(IAsutusRepository asutusRepository)
    {
        _asutusRepository = asutusRepository;
    }

    public async Task<QueryResultDto<AsutusShortDto>> Handle(AsutusteLoeteluRequest request
        , CancellationToken cancellationToken)
    {
        return await _asutusRepository.SearchAsync(request.Query, cancellationToken);
    }
}
