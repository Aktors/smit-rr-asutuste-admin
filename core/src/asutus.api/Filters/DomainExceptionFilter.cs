using asutus.api.Model.Model;
using asutus.common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace asutus.api.Filters;

public class DomainExceptionFilter : ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public DomainExceptionFilter()
    {
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            { typeof(NotFoundDomainException), HandleNotFoundException },
            { typeof(InvalidArgumentDomainException), HandleBadRequestException }
        };
    }
    
    public override void OnException(ExceptionContext context)
    {
        HandleException(context);
        base.OnException(context);
    }
    
    private void HandleException(ExceptionContext context)
    {
        Type type = context.Exception.GetType();
        
        if (_exceptionHandlers.TryGetValue(type, value: out var handler))
            handler.Invoke(context);
    }
    
    private void HandleNotFoundException(ExceptionContext context)
    {
        var exception = (NotFoundDomainException)context.Exception;

        var details = new RequestFault
        {
            Title = "The specified resource was not found.",
            Detail = exception.Message
        };

        context.Result = new NotFoundObjectResult(details);
        context.ExceptionHandled = true;
    }
    
    private void HandleBadRequestException(ExceptionContext context)
    {
        var exception = (InvalidArgumentDomainException)context.Exception;

        var details = new RequestFault
        {
            Title = "Bad Request.",
            Detail = exception.Message
        };

        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
    }
}