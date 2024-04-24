namespace NS.Domain.Common;

public class BaseEntity
{
    public long Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    protected BaseEntity()
    {
        CreationDate = DateTime.Now;
    }

    protected void Modified()
    {
        LastModifiedDate = DateTime.Now;
    }
}