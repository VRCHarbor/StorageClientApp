using StorageDBO.Entities.Base;

namespace StorageDBO.Entities;

public class OutRecordCount : RecordCount
{
    public OutRecord Record { get; set; } = null!;
}
