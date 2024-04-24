using FluentAssertions;
using NS.Domain.Entities.Product;

namespace Tests.DomainTests;


public class ProductTest
{
    readonly Product _product = new Product("Admin","Name", DateOnly.FromDateTime(DateTime.Today), "989903604430", "Mehrshad2028Gmail.com");
    [Fact]
    public void ProductName_Should_Not_BeNull()
    {
        //Arrange
        Product product;

        //Act
        product = _product;

        //Assert
        product.ProductName.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public void When_Product_Modified_ModifiedDate_ShouldBe_After_CreationDate()
    {
        //Arrange
        Product product = _product;
        
        //Act
        product.Edit("NewName", DateOnly.FromDateTime(DateTime.Today), "989903604430", "Mehrshad2028Gmail.com","Admin");
        
        //Assert
        product.LastModifiedDate.Should().BeAfter(product.CreationDate);
    }

    [Fact]
    public void Product_Should_BeChanged_OnlyBy_Creator()
    {
        //Arrange
        Product product = _product;
        
        //Act
        product.MakeAvailable("AnotherAdmin");
        
        //Assert
        product.IsAvailable.Should().BeFalse();
    }


}