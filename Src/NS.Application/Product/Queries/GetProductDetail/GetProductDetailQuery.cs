using MediatR;

namespace NS.Application.Product.Queries.GetProductDetail;

public class GetProductDetailQuery : IRequest<ProductViewModel>
{
    public long Id { get; set; }
}