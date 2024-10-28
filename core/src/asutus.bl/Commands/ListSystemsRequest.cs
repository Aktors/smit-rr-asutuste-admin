using asutus.common.Model;
using MediatR;

namespace asutus.bl.Commands;

public class ListSystemsRequest : IRequest<InformationSystemDto[]> { }