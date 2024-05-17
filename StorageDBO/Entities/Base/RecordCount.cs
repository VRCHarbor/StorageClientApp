namespace StorageDBO.Entities.Base;

public abstract class RecordCount : BaseEntity<int>
{
    public int ArticulId { get; set; }
    public Articul Articul { get; set; } = null!;
    public int Count { get; set; }

    public int RecordId { get; set; }

}
