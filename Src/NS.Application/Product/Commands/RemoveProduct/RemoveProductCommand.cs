using MediatR;
using NS.Application.Common;

namespace NS.Application.Product.Commands.RemoveProduct;

public class RemoveProductCommand : IRequest<BaseResponse>
{
    public long Id { get; set; }
}