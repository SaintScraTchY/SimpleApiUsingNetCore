using System.Net;
using AutoMapper;
using MediatR;
using NS.Application.Exceptions;
using NS.Domain.Entities.Product;

namespace NS.Application.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand,UpdateProductCommandResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    //TODO
    public async Task<UpdateProductCommandResponse> 
        Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        
        var validationResult = await 
            new UpdateProductCommandValidator().ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new CommandValidationException(validationResult);
        
        var response = new UpdateProductCommandResponse();
        var product = await _productRepository.GetByIdAsync(request.Id);
        product.Edit(request.ProductName,request.ProduceDate,request.ManufacturePhone,request.ManufactureEmail,"Admin");
        _productRepository.SaveChanges();
        
        response.Succeeded(HttpStatusCode.OK, "Updated");
        return response;
    }
}