using FluentValidation;
using FluentValidation.Validators;

namespace NS.Application.Product.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(ae => ae.Id)
            .NotNull()
            .GreaterThan(0);
        
        RuleFor(ae => ae.ProductName)
            .NotEmpty()
            .MaximumLength(150);
        
        RuleFor(ae => ae.ProduceDate)
            .NotNull();
        
        RuleFor(ae => ae.ManufactureEmail)
            .NotEmpty()
            .EmailAddress(EmailValidationMode.AspNetCoreCompatible);
        
        RuleFor(ae => ae.ManufacturePhone)
            .Matches(@"/^(0|0098|\\+98)9(0[1-5]|[1 3]\\d|2[0-2]|98)\\d{7}$/gm");
    }
    
}