using MediatR;

namespace NS.Application.Product.Queries.GetProductList;

public class GetProductListQuery : IRequest<List<ProductViewModel>>
{
    public string CreatorName { get; set; } = string.Empty;
}