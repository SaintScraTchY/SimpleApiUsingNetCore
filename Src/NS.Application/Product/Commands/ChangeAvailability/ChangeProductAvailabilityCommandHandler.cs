using AutoMapper;
using MediatR;
using NS.Application.Exceptions;
using NS.Domain.Entities.Product;

namespace NS.Application.Product.Commands.ChangeAvailability;

public class ChangeProductAvailabilityCommandHandler : IRequestHandler<ChangeProductAvailabilityCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ChangeProductAvailabilityCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    //TODO
    public async Task Handle(ChangeProductAvailabilityCommand request, CancellationToken cancellationToken)
    {

        var validationResult = await new ChangeProductAvailabilityValidator()
            .ValidateAsync(request,cancellationToken);

        if (validationResult.Errors.Count > 0)
            throw new CommandValidationException(validationResult);
        
        var product = await _productRepository.GetByIdAsync(request.Id);
        if (request.AvailabilityState)
        {
            product.MakeAvailable("admin");
        }
        else
        {
            product.MakeNotAvailable("admin");
        }
        _productRepository.SaveChanges();
        return;
    }
}