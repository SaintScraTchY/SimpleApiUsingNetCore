using FluentValidation;
using FluentValidation.Validators;
using NS.Domain.Entities.Product;

namespace NS.Application.Product.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    
    public CreateProductCommandValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository;
        RuleFor(ae => ae.ProductName)
            .NotEmpty()
            .MaximumLength(150);
        
        RuleFor(ae => ae.ProduceDate)
            .NotNull()
            .MustAsync(IsProduceDateUnique);

        RuleFor(ae => ae.ManufactureEmail)
            .NotEmpty()
            .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
            .MustAsync(IsProductEmailUnique);

        RuleFor(ae => ae.ManufacturePhone)
            .Matches(@"/^(0|0098|\\+98)9(0[1-5]|[1 3]\\d|2[0-2]|98)\\d{7}$/gm");
    }

    private async Task<bool> IsProductEmailUnique(string email, CancellationToken token)
    {
        return await _productRepository.IsProductEmailUnique(email);
    }
    
    private async Task<bool> IsProduceDateUnique(DateOnly date, CancellationToken token)
    {
        return await _productRepository.IsProduceDateUnique(date);
    }
}