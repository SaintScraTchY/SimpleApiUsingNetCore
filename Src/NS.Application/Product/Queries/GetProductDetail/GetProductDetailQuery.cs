using MediatR;

namespace NS.Application.Product.Queries;

public class GetProductDetailQuery : IRequest<ProductViewModel>
{
    public long Id { get; set; }
}