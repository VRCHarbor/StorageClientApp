namespace StorageDBO.Entities.Base;

public abstract class ChangeRecord : BaseEntity<int>
{
    public DateOnly ChangeDate { get; set; }
}
