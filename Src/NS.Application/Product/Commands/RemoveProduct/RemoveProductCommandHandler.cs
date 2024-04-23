using AutoMapper;
using MediatR;
using NS.Domain.Entities.Product;

namespace NS.Application.Product.Commands.RemoveProduct;

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand,bool>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public RemoveProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    //TODO
    public async Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        product.Remove("Admin");
        _productRepository.SaveChanges();
        return true;
    }
}