namespace NS.Domain.Common;

public class BaseEntity
{
    public long Id { get; private set; }
    public DateTime CreationDate { get; init; }
    public DateTime ModifiedDate { get; protected set; }

    protected BaseEntity()
    {
        CreationDate = DateTime.Now;
        ModifiedDate = CreationDate;
    }
}