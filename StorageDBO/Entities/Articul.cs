using StorageDBO.Entities.Base;

namespace StorageDBO.Entities;

public class Articul : BaseEntity<int>
{
    public string ArticulSellerCode { get; set; }
    public string? ArticulName { get; set; }
    public string? ArticulImage { get; set; }

    public int? ArticulGroupID { get; set; }
    public ArticulGroup? ArticulGroup { get; set; }
}
