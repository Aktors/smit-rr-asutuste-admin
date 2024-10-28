using asutus.common.Model;
using FluentValidation;

namespace asutus.api.Domain.Validations;

public class AsutusShortDtoValidator: AbstractValidator<AsutusShortDto>
{
    public AsutusShortDtoValidator()
    {
        RuleFor(asutus => asutus.Code)
            .NotEmpty().NotEmpty().WithMessage("Code is required.");
        
        RuleFor(asutus => asutus.Name)
            .NotEmpty().NotEmpty().WithMessage("Name is required.");
        
        RuleFor(asutus => asutus.StartDate)
            .NotNull().WithMessage("StartDate is required.");
        
        RuleFor(asutus => asutus.EndDate)
            .GreaterThan(asutus => asutus.StartDate).When(asutus => asutus.EndDate.HasValue)
            .WithMessage("EndDate must be after StartDate if specified.");
    }
}