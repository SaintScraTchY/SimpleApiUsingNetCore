using FluentValidation;

namespace NS.Application.Product.Commands.ChangeAvailability;

public class ChangeProductAvailabilityValidator : AbstractValidator<ChangeProductAvailabilityCommand>
{
    public ChangeProductAvailabilityValidator()
    {
        RuleFor(ae => ae.Id)
            .NotNull()
            .GreaterThan(0);

        RuleFor(ae => ae.AvailabilityState)
            .NotNull();
    }
}