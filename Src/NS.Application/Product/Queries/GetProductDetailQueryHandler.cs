using AutoMapper;
using MediatR;
using NS.Domain.Entities.Product;

namespace NS.Application.Product.Queries;

public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery,ProductViewModel>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductDetailQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductViewModel> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id) ?? null;
        return _mapper.Map<ProductViewModel>(product);
    }
}