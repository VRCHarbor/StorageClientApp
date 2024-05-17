using StorageDBO.Entities.Base;

namespace StorageDBO.Entities;

public class InRecord : ChangeRecord
{
    public ICollection<InRecordCount> Records { get; set; } = [];
}
