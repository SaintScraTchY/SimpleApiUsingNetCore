using System.Net;
using AutoMapper;
using MediatR;
using NS.Application.Common;
using NS.Application.Exceptions;
using NS.Domain.Entities.Product;

namespace NS.Application.Product.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,CreateProductCommandResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        BaseResponse baseResponse = new BaseResponse();

        var validationResult = await 
            new CreateProductCommandValidator(_productRepository).ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new CommandValidationException(validationResult);
        
        var command = _mapper.Map<Domain.Entities.Product.Product>(request);
        var response = new CreateProductCommandResponse();
        Domain.Entities.Product.Product product 
            = new Domain.Entities.Product.Product
            ("Admin",command.ProductName, command.ProduceDate, command.ManufacturePhone, command.ManufactureEmail);
        command = await _productRepository.CreateAsync(product);

        response.CreatedProductId = command.Id;
        _productRepository.SaveChanges();
        response.Succeeded(HttpStatusCode.OK,"ProductCreated");
        
        return response;
    }
}