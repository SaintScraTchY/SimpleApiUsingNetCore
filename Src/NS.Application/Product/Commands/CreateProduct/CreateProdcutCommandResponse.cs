using NS.Application.Common;

namespace NS.Application.Product.Commands.CreateProduct;

public class CreateProductCommandResponse : BaseResponse
{
    public long CreatedProductId { get; set; }

    public CreateProductCommandResponse()
    {
        
    }
}