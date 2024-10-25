using asutus.common.Model;
using MediatR;

namespace asutus.api.Commands;

public class AsutusByKoodCommand: IRequest<AsutusDto?>
{
    public string Code { get; }

    public AsutusByKoodCommand(string code)
    {
        Code = code;
    }
}