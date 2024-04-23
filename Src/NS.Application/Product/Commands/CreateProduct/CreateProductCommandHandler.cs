using AutoMapper;
using MediatR;
using NS.Application.Product.Queries;
using NS.Domain.Entities.Product;

namespace NS.Application.Product.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,long>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<Domain.Entities.Product.Product>(request);
        Domain.Entities.Product.Product product 
            = new Domain.Entities.Product.Product
            (command.ProductName, command.ProduceDate, command.ManufacturePhone, command.ManufactureEmail, "Admin");
        command = await _productRepository.CreateAsync(command);

        return command.Id;
    }
}