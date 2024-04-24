using MediatR;

namespace NS.Application.Product.Commands.CreateProduct;

public class CreateProductCommand : IRequest<CreateProductCommandResponse>
{
    public string ProductName { get; set; }
    public DateOnly ProduceDate { get; set; }
    public string ManufacturePhone { get; set; }
    public string ManufactureEmail { get; set; }
}