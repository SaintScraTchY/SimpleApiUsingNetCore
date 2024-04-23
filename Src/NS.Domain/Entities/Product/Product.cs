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
    public bool IsRemoved { get; private set; } = false;

    public bool IsProductCreator(string username) => username == CreatedBy;
    
    public void Edit(string productName, DateOnly produceDate, string manufacturePhone, string manufactureEmail,string currentuser)
    {
        if(!IsProductCreator(currentuser))
            return;
        
        ProductName = productName;
        ProduceDate = produceDate;
        ManufacturePhone = manufacturePhone;
        ManufactureEmail = manufactureEmail;
        Modified();
    }

    public void MakeAvailable(string currentuser)
    {
        if(!IsProductCreator(currentuser))
            return;
        
        IsAvailable = true;
        Modified();
    }
    public void MakeNotAvailable(string currentuser)
    {
        if(!IsProductCreator(currentuser))
            return;
        
        IsAvailable = false;
        Modified();
    }

    public void Remove(string currentuser)
    {
        if(!IsProductCreator(currentuser))
            return;
        
        IsRemoved = true;
        Modified();
    }
    
    public void Restore(string currentuser)
    {
        if(!IsProductCreator(currentuser))
            return;
        
        IsRemoved = false;
        Modified();
    }
}