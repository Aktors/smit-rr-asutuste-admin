using asutus.api.Model;
using FluentValidation;

namespace asutus.api.Domain.Validations;

public class PagedQueryValidator: AbstractValidator<PagedQuery>
{
    public PagedQueryValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0).WithMessage("Page number must be greater than 0.");
        RuleFor(x => x.PageSize).InclusiveBetween(1, 100).WithMessage("Page size must be between 1 and 100.");
        RuleFor(x => x.SortOrder)
            .Must(value => value == null || value.ToLower() == "asc" || value.ToLower() == "desc")
            .WithMessage("Sort order must be 'asc' or 'desc'.");
    }
}