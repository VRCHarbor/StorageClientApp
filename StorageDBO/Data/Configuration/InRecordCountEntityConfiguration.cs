using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageDBO.Entities;

namespace StorageDBO.Data.Configuration;

public class InRecordCountEntityConfiguration : IEntityTypeConfiguration<InRecordCount>
{
    public void Configure(EntityTypeBuilder<InRecordCount> builder)
    {
        builder.ToTable("InRecords");
        builder.HasIndex(x => new { x.RecordId, x.ArticulId });
    }
}
