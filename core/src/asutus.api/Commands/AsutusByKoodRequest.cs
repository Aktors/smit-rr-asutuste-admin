using asutus.common.Model;
using MediatR;

namespace asutus.api.Commands;

public class AsutusByKoodRequest: IRequest<AsutusDto?>
{
    public string Code { get; }

    public AsutusByKoodRequest(string code)
    {
        Code = code;
    }
}