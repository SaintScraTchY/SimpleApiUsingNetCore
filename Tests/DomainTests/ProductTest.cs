using FluentAssertions;
using NS.Domain.Entities.Product;

namespace Tests.DomainTests;


public class ProductTest
{
    readonly Product _product = new Product("Name", DateOnly.FromDateTime(DateTime.Today), "989903604430", "Mehrshad2028Gmail.com","Admin");
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
        product.Edit("NewName", DateOnly.FromDateTime(DateTime.Today), "989903604430", "Mehrshad2028Gmail.com","AnotherAdmin");
        
        //Assert
        product.LastModifiedDate.Should().BeAfter(product.CreationDate);
    }

    public void LastModifiedBy_ShouldNot_BeNull_After_Modifying()
    {
        //Arrange
        Product product = _product;
        
        //Act
        product.Edit("NewName", DateOnly.FromDateTime(DateTime.Today), "989903604430", "Mehrshad2028Gmail.com","AnotherAdmin");
        
        //Assert
        product.LastModifiedBy.Should().NotBeNullOrWhiteSpace();
    }



}