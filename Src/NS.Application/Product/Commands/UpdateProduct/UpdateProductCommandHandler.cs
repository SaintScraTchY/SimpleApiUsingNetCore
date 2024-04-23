using AutoMapper;
using MediatR;
using NS.Domain.Entities.Product;

namespace NS.Application.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand,long>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    //TODO
    public async Task<long> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        product.Edit(request.ProductName,request.ProduceDate,request.ManufacturePhone,request.ManufactureEmail,"Admin");
        _productRepository.SaveChanges();
        return product.Id;
    }
}