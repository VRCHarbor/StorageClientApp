using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageDBO.Entities;

namespace StorageDBO.Data.Configuration;

public class OutRecordCountEntityConfiguration : IEntityTypeConfiguration<OutRecordCount>
{
    public void Configure(EntityTypeBuilder<OutRecordCount> builder)
    {
        builder.ToTable("OutRecords");
        builder.HasIndex(x => new { x.RecordId, x.ArticulId });
    }
}