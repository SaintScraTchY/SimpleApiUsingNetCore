using NS.Domain.Common;

namespace NS.Domain.Entities.Product;

public class Product : BaseEntity
{
    public string ProductName { get; private set; } 
    public DateOnly ProduceDate { get; private set; } 
    public string ManufacturePhone { get; private set; } 
    public string ManufactureEmail { get; private set; } 
    public bool IsAvailable { get; private set; } = false;
    public bool IsRemoved { get; private set; } = false;

    public bool IsProductCreator(string username) => username == CreatedBy;

    public Product()
    {
        
    }
    public Product(string creatorUserName, string productName, DateOnly produceDate, string manufacturePhone, string manufactureEmail) 
    {
        ProductName = productName;
        ProduceDate = produceDate;
        ManufacturePhone = manufacturePhone;
        ManufactureEmail = manufactureEmail;
        CreatedBy = creatorUserName;
    }

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