using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NS.Application.Common;
using NS.Application.Product.Commands.ChangeAvailability;
using NS.Application.Product.Commands.CreateProduct;
using NS.Application.Product.Commands.RemoveProduct;
using NS.Application.Product.Commands.UpdateProduct;
using NS.Application.Product.Queries;
using NS.Application.Product.Queries.GetProductDetail;
using NS.Application.Product.Queries.GetProductList;

namespace NS.Api.Controllers.v1;

[ApiController]
[Route("Api/v1/[controller]/[action]")]
public class ProductController
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[Authorize]
    [HttpPost("/Create")]
    public async Task<ActionResult<CreateProductCommandResponse>> 
        CreateProduct([FromBody] CreateProductCommand command)
    {
        var response = await _mediator.Send(command);
        return response;
    }
    
    //[Authorize]
    [HttpPost("/Update")]
    public async Task<ActionResult<UpdateProductCommandResponse>> 
        UpdateProduct([FromBody] UpdateProductCommand command)
    {
        var response = await _mediator.Send(command);
        return response;
    }
    
    //[Authorize]
    [HttpPost("/ChangeAvailability")]
    public async Task<ActionResult<BaseResponse>> 
        ChangeAvailability([FromBody] ChangeProductAvailabilityCommand command)
    {
        var response = await _mediator.Send(command);
        return response;
    }
    
    //[Authorize]
    [HttpGet(Name = "Remove")]
    public async Task<ActionResult<BaseResponse>> 
        RemoveProduct(long id)
    {
        RemoveProductCommand command = new RemoveProductCommand() { Id = id };
        var response = await _mediator.Send(id);
        return (BaseResponse)response;
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
    
    [HttpGet("Detail",Name = "GetProductDetail")] [AllowAnonymous]
    public async Task<ActionResult<ProductViewModel>> GetAllProductByCreatorName(long productId)
    {
        GetProductDetailQuery getProductDetail = new GetProductDetailQuery()
        {
            Id = productId
        };
        
        var responseDto = await _mediator.Send(getProductDetail);
        return responseDto;
    }
}