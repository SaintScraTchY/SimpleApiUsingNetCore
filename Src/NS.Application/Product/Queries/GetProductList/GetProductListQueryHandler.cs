using AutoMapper;
using MediatR;
using NS.Domain.Entities.Product;

namespace NS.Application.Product.Queries.GetProductList;

public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery,List<ProductViewModel>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductListQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }


    //TODO
    public async Task<List<ProductViewModel>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var allProducts = (await _productRepository.GetProductListBy(request.CreatorName)).OrderBy(x=>x.CreationDate);
        return _mapper.Map<List<ProductViewModel>>(allProducts);
    }
}