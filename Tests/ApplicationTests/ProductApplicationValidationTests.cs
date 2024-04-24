using AutoMapper;
using NS.Application.Exceptions;
using NS.Application.Product.Commands.CreateProduct;
using NS.Domain.Entities.Product;
using NS.Infrastructure.MSSQL.EFCore.Repositories;

namespace Tests.ApplicationTests;

public class ProductApplicationValidationTests
{
    //Dependency
    private IMapper _mapperMock;
    private IProductRepository _productRepoMock;
    
    //MockData
    
    
    //SUT
    private CreateProductCommandHandler CreateHandler;
    
    
    public ProductApplicationValidationTests()
    {
        _productRepoMock = A.Fake<ProductRepository>();
        _mapperMock = A.Fake<Mapper>();
    }
    
    [Fact]
    public void ThrowValidationException_If_Email_IsInvalid()
    {
        //Arrange
        CreateHandler = new CreateProductCommandHandler(_productRepoMock,_mapperMock);
        CreateProductCommand command = new CreateProductCommand
        {
            ProductName = "Name",
            ProduceDate = DateOnly.FromDateTime(DateTime.Today),
            ManufacturePhone = "+989903604430",
            ManufactureEmail = "InvalidEmailExample.com"
        };
        CancellationToken token = new CancellationToken();
        //Act
        var act = () => CreateHandler.Handle(command, token);

        //Assert
        act.Should().ThrowAsync<CommandValidationException>();
    }
    
    [Fact]
    public void When_Product_ManufactureEmail_isInvalid_Should_ThrowIncorrectEmailFormatException()
    {
        //Arrange
        
        //Act
        
        //Assert
    }
    
    [Fact]
    public void When_Product_ManufacturePhone_isInvalid_Should_ThrowIncorrectPhoneFormatException()
    {
        //Arrange
        
        //Act
        
        //Assert
    }
}