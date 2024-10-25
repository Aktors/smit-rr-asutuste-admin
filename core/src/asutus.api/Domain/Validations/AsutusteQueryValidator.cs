using asutus.api.Model;
using FluentValidation;

namespace asutus.api.Domain.Validations;

public class AsutusteQueryValidator : AbstractValidator<AsutusteQuery>
{
    public AsutusteQueryValidator()
    {
        Include(new PagedQueryValidator());

        RuleFor(query => query.StartDate)
            .LessThan(query => query.EndDate)
            .When(query => query.StartDate.HasValue && query.EndDate.HasValue)
            .WithMessage("StartDate must be before EndDate if both are specified.");
    }
}