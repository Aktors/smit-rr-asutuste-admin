using asutus.common.Model;
using MediatR;

namespace asutus.api.Commands;

public class ListSystemsRequest : IRequest<InformationSystemDto[]> { }