using asutus.common.Model;
using FluentValidation;

namespace asutus.api.Domain.Validations;

public class AsutusDtoValidator : AbstractValidator<AsutusDto>
{
    public AsutusDtoValidator()
    {
        Include(new AsutusShortDtoValidator());
        
        RuleFor(asutus => asutus.Translations)
            .NotNull().WithMessage("Translations cannot be null.")
            .Must(translations => translations.Count > 0).WithMessage("Translations must contain at least one element.");
    }
}