using MediatR;

namespace asutus.bl.Commands;

public class DeleteAsutusByCodeRequest : IRequest<Unit>
{
    public string Code { get; }

    public DeleteAsutusByCodeRequest(string code)
    {
        Code = code;
    }
}