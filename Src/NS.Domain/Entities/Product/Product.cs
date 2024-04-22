using NS.Domain.Common;

namespace NS.Domain.Entities.Product;

public class Product(
    string productName,
    DateOnly produceDate,
    string manufacturePhone,
    string manufactureEmail,
    string creatorUserName)
    : BaseEntity(creatorUserName)
{
    public string ProductName { get; private set; } = productName;
    public DateOnly ProduceDate { get; private set; } = produceDate;
    public string ManufacturePhone { get; private set; } = manufacturePhone;
    public string ManufactureEmail { get; private set; } = manufactureEmail;
    public bool IsAvailable { get; private set; } = false;

    public void Edit(string productName, DateOnly produceDate, string manufacturePhone, string manufactureEmail,string modifierUserName)
    {
        ProductName = productName;
        ProduceDate = produceDate;
        ManufacturePhone = manufacturePhone;
        ManufactureEmail = manufactureEmail;
        Modified(modifierUserName);
    }

    public void MakeAvailable(string modifierUserName)
    {
        IsAvailable = true;
        Modified(modifierUserName);
    }

    public void MakeNotAvailable(string modifierUserName)
    {
        IsAvailable = false;
        Modified(modifierUserName);
    }
}