using System.Net;
using AutoMapper;
using MediatR;
using NS.Application.Common;
using NS.Application.Exceptions;
using NS.Application.Product.Commands.UpdateProduct;
using NS.Domain.Entities.Product;

namespace NS.Application.Product.Commands.RemoveProduct;

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand,BaseResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public RemoveProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    //TODO
    public async Task<BaseResponse> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        BaseResponse response = new BaseResponse();
        var validationResult = await 
            new RemoveProductCommandValidator().ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new CommandValidationException(validationResult);
        
        var product = await _productRepository.GetByIdAsync(request.Id);
        product.Remove("Admin");
        _productRepository.SaveChanges();
        response.Succeeded(HttpStatusCode.OK,"Removed");
        return response;
    }
}