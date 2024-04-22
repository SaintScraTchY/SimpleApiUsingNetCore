using FluentAssertions;

namespace Tests.EntitiesTest;


public class ProductTest
{
    public class BaseEntity
    {
        public long Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime ModifiedDate { get; private set; }

        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            ModifiedDate = CreationDate;
        }
    }
    public class Product
    {
        public string ProductName { get; private set; }
        public DateTime ProduceDateTime { get; private set; }
        public string ManufacturePhone { get; private set; }
        public string ManufactureEmail { get; private set; }
        public bool IsAvailable { get; private set; } = false;

        public Product(string productName, DateTime produceDateTime, string manufacturePhone, string manufactureEmail)
        {
            ProductName = productName;
            ProduceDateTime = produceDateTime;
            ManufacturePhone = manufacturePhone;
            ManufactureEmail = manufactureEmail;
        }

        public void Edit(string productName, DateTime produceDateTime, string manufacturePhone, string manufactureEmail)
        {
            ProductName = productName;
            ProduceDateTime = produceDateTime;
            ManufacturePhone = manufacturePhone;
            ManufactureEmail = manufactureEmail;
        }

        public void MakeAvailable()
        {
            IsAvailable = true;
        }

        public void MakeNotAvailable()
        {
            IsAvailable = false;
        }
    }
    
    [Fact]
    public void ProductName_Should_Not_BeNull()
    {
        //Arrange
        Product product = new Product("Name", DateTime.Now, "989903604430", "Mehrshad2028Gmail.com");

        //Act

        //Assert
        product.ProductName.Should().NotBeNullOrWhiteSpace();

    }

}