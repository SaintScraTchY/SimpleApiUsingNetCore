using FluentValidation;

namespace NS.Application.Product.Commands.RemoveProduct;

public class RemoveProductCommandValidator : AbstractValidator<RemoveProductCommand>
{
    public RemoveProductCommandValidator()
    {
        RuleFor(ae => ae.Id)
            .NotNull()
            .GreaterThan(0);
        
    }
}