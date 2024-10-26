using asutus.common.Model;
using FluentValidation;

namespace asutus.api.Domain.Validations;

public class TranslationValidator : AbstractValidator<TranslationDto>
{
    public TranslationValidator()
    {
        RuleFor(translation => translation.Code)
            .NotEmpty().WithMessage("Translation code is required.");
        
        RuleFor(translation => translation.Text)
            .NotEmpty().WithMessage("Translation text is required.");
    }
}
