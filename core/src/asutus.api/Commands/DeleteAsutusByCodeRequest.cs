using MediatR;

namespace asutus.api.Commands;

public class DeleteAsutusByCodeRequest : IRequest<Unit>
{
    public string Code { get; }

    public DeleteAsutusByCodeRequest(string code)
    {
        Code = code;
    }
}