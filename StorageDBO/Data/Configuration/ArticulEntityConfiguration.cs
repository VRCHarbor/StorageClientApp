using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageDBO.Entities;

namespace StorageDBO.Data.Configuration;

public class ArticulEntityConfiguration : IEntityTypeConfiguration<Articul>
{
    public void Configure(EntityTypeBuilder<Articul> builder)
    {
        builder.Property(i => i.ArticulGroupID).IsRequired(false);
        builder
            .HasOne(i => i.ArticulGroup)
            .WithMany(i => i.Articuls)
            .HasForeignKey(i => i.ArticulGroupID);
    }
}
