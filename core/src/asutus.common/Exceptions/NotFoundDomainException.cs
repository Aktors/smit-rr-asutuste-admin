namespace asutus.common.Exceptions;

public class NotFoundDomainException : BaseDomainException
{
    public NotFoundDomainException() { }
    
    public NotFoundDomainException(string message) : base(message) { }
}