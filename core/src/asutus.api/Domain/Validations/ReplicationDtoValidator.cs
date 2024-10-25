using asutus.common.Model;
using FluentValidation;

namespace asutus.api.Domain.Validations;

public class ReplicationDtoValidator: AbstractValidator<ReplicationDto>
{
    public ReplicationDtoValidator()
    {
        RuleFor(replication => replication.Code)
            .NotEmpty().WithMessage("Code is required.");
        
        RuleFor(replication => replication.Environments)
            .NotNull().WithMessage("Environments cannot be null.")
            .Must(env => env.Length > 0).WithMessage("Environments must contain at least one element.");
    }
}