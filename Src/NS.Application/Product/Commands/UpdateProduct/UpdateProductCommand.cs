using MediatR;

namespace NS.Application.Product.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<UpdateProductCommandResponse>
{
    public long Id { get; set; }
    public string ProductName { get; set; }
    public DateOnly ProduceDate { get; set; }
    public string ManufacturePhone { get; set; }
    public string ManufactureEmail { get; set; }
}