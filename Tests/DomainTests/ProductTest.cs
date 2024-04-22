using FluentAssertions;
using NS.Domain.Entities.Product;

namespace Tests.DomainTests;


public class ProductTest
{
    [Fact]
    public void ProductName_Should_Not_BeNull()
    {
        //Arrange
        Product product;

        //Act
        product = new Product("Name", DateOnly.FromDateTime(DateTime.Today), "989903604430", "Mehrshad2028Gmail.com");

        //Assert
        product.ProductName.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public void When_Product_Modified_ModifiedDate_ShouldBe_After_CreationDate()
    {
        //Arrange
        Product product = new Product("Name", DateOnly.FromDateTime(DateTime.Today), "989903604430", "Mehrshad2028Gmail.com");
        
        //Act
        DateTime beforeModifyingDateTime = product.ModifiedDate;
        product.Edit("NewName", DateOnly.FromDateTime(DateTime.Today), "989903604430", "Mehrshad2028Gmail.com");
        
        //Assert
        product.ModifiedDate.Should().BeAfter(beforeModifyingDateTime);
    }

    public void When_Product_ManufactureEmail_isInvalid_Should_ThrowIncorrectEmailFormatException()
    {
        //Arrange
        
        //Act
        
        //Assert
    }
    
    public void When_Product_ManufacturePhone_isInvalid_Should_ThrowIncorrectPhoneFormatException()
    {
        //Arrange
        
        //Act
        
        //Assert
    }

}