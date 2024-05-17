using System;
using Microsoft.EntityFrameworkCore;

using StorageDBO.Entities;

namespace StorageDBO
{
    public class StorageDBContext : DbContext
    {
        public DbSet<Articul> Articuls => Set<Articul>();      
        public DbSet<InRecordCount> InRecords => Set<InRecordCount>();
        public DbSet<OutRecordCount> OutRecords => Set<OutRecordCount>();
        public DbSet<ArticulGroup> ArticulGroups => Set<ArticulGroup>();
        public DbSet<OutRecord> Expenses => Set<OutRecord>();
        public DbSet<InRecord> Incomes => Set<InRecord>();

        public StorageDBContext(DbContextOptions<StorageDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var articulsEnt = modelBuilder.Entity<Articul>();
            var InRecordsEnt = modelBuilder.Entity<InRecordCount>();
            var OutRecordsEnt = modelBuilder.Entity<OutRecordCount>();
            var GroupsEnt = modelBuilder.Entity<ArticulGroup>();
            var ExpEnt = modelBuilder.Entity<OutRecord>();
            var InEnt = modelBuilder.Entity<InRecord>();

            articulsEnt.HasKey(i => i.ArticulSellerCode);
            articulsEnt.Property(i => i.ArticulName).IsRequired(true);
            articulsEnt.HasOne(i => i.ArticulGroup).WithMany(i => i.Articuls).HasForeignKey(i => i.ArticulGroupID).IsRequired(false);
            articulsEnt.Property(i => i.ArticulImage).IsRequired(false);

            InRecordsEnt.HasKey(i => new { i.RecordId, i.ArticulID });
            InRecordsEnt.ToTable("InRecords");

            OutRecordsEnt.HasKey(i => new { i.RecordId, i.ArticulID });
            OutRecordsEnt.ToTable("OutRecords");

            GroupsEnt.HasKey(i => i.Id);
            GroupsEnt.Property(i => i.Name).IsRequired(true);

            ExpEnt.HasKey(i => i.ChangeDate);
            ExpEnt.HasMany(i => i.Records).WithOne(i => i.Record).HasForeignKey(i => i.RecordId);
            //ExpEnt.Navigation(i => i.Records).IsRequired(true);
            ExpEnt.ToTable("Expenses");

            InEnt.HasKey(i => i.ChangeDate);
            InEnt.HasMany(i => i.Records).WithOne(i => i.Record).HasForeignKey(i => i.RecordId);
            //InEnt.Navigation(i => i.Records).IsRequired(true);
            InEnt.ToTable("Incomes");

            base.OnModelCreating(modelBuilder);
        }


    }
}
