using AutoMapper;
using MediatR;
using NS.Domain.Entities.Product;

namespace NS.Application.Product.Queries;

public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery,List<ProductViewModel>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductListQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }


    public async Task<List<ProductViewModel>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var allProducts = (await _productRepository.GetAllAsync()).OrderBy(x=>x.CreationDate);
        return _mapper.Map<List<ProductViewModel>>(allProducts);
    }
}