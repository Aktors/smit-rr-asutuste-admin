namespace asutus.common.Exceptions;

public class InvalidArgumentDomainException : BaseDomainException
{
    public InvalidArgumentDomainException(String message) : base(message){ }
    
    public InvalidArgumentDomainException(String message, Exception innerException) : base(message, innerException) { }
    
}