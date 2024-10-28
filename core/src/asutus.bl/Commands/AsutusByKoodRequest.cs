using asutus.common.Model;
using MediatR;

namespace asutus.bl.Commands;

public class AsutusByKoodRequest: IRequest<AsutusDto?>
{
    public string Code { get; }

    public AsutusByKoodRequest(string code)
    {
        Code = code;
    }
}