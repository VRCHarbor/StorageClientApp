using StorageDBO.Entities.Base;

namespace StorageDBO.Entities;

public class ArticulGroup : BaseEntity<int>
{
    public required string Name { get; set; }
    public ICollection<Articul> Articuls { get; set; } = [];
}
