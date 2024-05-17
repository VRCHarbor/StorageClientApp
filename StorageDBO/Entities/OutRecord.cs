using StorageDBO.Entities.Base;

namespace StorageDBO.Entities;

public class OutRecord : ChangeRecord
{
    public ICollection<OutRecordCount> Records { get; set; } = [];
}
