using MediatR;

namespace NS.Application.Product.Commands.RemoveProduct;

public class RemoveProductCommand : IRequest<bool>
{
    public long Id { get; set; }
}