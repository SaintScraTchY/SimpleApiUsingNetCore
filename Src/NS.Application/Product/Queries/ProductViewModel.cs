namespace NS.Application.Product.Queries;

public class ProductViewModel
{
    public long ProductId { get; set; }
    public string ProductName { get; set; } 
    public string ProduceDate { get; set; } 
    public string ManufacturePhone { get; set; }
    public string ManufactureEmail { get; set; }
    public bool IsAvailable { get; set; }
    
    public string CreatedBy { get; set; }
    public string CreationDate { get; set; }
    public string LastModifiedDate { get; set; }
}