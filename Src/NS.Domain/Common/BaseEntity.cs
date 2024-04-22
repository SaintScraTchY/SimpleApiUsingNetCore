namespace NS.Domain.Common;

public class BaseEntity
{
    public long Id { get; private set; }
    public string CreatedBy { get; private set; }
    public DateTime CreationDate { get; init; }
    public string? LastModifiedBy { get; private set; }
    public DateTime? LastModifiedDate { get; protected set; }

    protected BaseEntity(string creatorUserName)
    {
        CreationDate = DateTime.Now;
        CreatedBy = creatorUserName;
    }

    protected void Modified(string modifierUserName)
    {
        LastModifiedBy = modifierUserName;
        LastModifiedDate = DateTime.Now;
    }
}