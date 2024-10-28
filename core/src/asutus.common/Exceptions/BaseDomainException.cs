namespace asutus.common.Exceptions;

public class BaseDomainException: Exception
{
    public BaseDomainException(){ }
    public BaseDomainException(String message) : base(message){ }
    
    public BaseDomainException(String message, Exception inner) : base(message, inner){ }
    
}