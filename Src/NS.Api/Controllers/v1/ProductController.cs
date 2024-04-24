using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NS.Application.Product.Commands.CreateProduct;
using NS.Application.Product.Queries;
using NS.Application.Product.Queries.GetProductList;

namespace NS.Api.Controllers.v1;

[ApiController]
[Route("Api/v1/[controller]")]
public class ProductController
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("All",Name = "GetAllProducts")] [AllowAnonymous]
    public async Task<ActionResult<List<ProductViewModel>>> GetAllProductByCreatorName(string? createdBy)
    {
        GetProductListQuery getProductListQuery = new GetProductListQuery()
        {
            CreatorName = createdBy
        };
        
        var responseDto = await _mediator.Send(getProductListQuery);
        return responseDto;
    }

    [HttpPost(Name = "CreateProduct")]
    public async Task<ActionResult<CreateProductCommandResponse>> 
        CreateProduct([FromBody] CreateProductCommand command)
    {
        var response = await _mediator.Send(command);
        return response;
    }
}