using asutus.common.Model;
using MediatR;

namespace asutus.api.Commands;

public class ClassifierByGroupRequest: IRequest<ClassifierDto[]>
{
    public string Code { get; }

    public ClassifierByGroupRequest(string code)
    {
        Code = code;
    }
}