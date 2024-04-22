using NS.Domain.Common;

namespace NS.Domain.Entities.Product;

public class Product : BaseEntity
{
    public string ProductName { get; private set; }
    public DateOnly ProduceDate { get; private set; }
    public string ManufacturePhone { get; private set; }
    public string ManufactureEmail { get; private set; }
    public bool IsAvailable { get; private set; } = false;

    public Product(string productName, DateOnly produceDate, string manufacturePhone, string manufactureEmail)
    {
        ProductName = productName;
        ProduceDate = produceDate;
        ManufacturePhone = manufacturePhone;
        ManufactureEmail = manufactureEmail;
    }

    public void Edit(string productName, DateOnly produceDate, string manufacturePhone, string manufactureEmail)
    {
        ProductName = productName;
        ProduceDate = produceDate;
        ManufacturePhone = manufacturePhone;
        ManufactureEmail = manufactureEmail;
        ModifiedDate = DateTime.Now;
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