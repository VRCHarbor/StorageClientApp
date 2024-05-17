using StorageDBO.Entities.Base;

namespace StorageDBO.Entities;

public class InRecordCount : RecordCount
{
    public InRecord Record { get; set; } = null!;
}