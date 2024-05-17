using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using StorageDBO.Entities;

namespace StorageDBO.Data
{
    public class StorageDBContext(DbContextOptions<StorageDBContext> options) : DbContext(options)
    {
        public DbSet<Articul> Articuls => Set<Articul>();
        public DbSet<InRecordCount> InRecords => Set<InRecordCount>();
        public DbSet<OutRecordCount> OutRecords => Set<OutRecordCount>();
        public DbSet<ArticulGroup> ArticulGroups => Set<ArticulGroup>();
        public DbSet<OutRecord> Expenses => Set<OutRecord>();
        public DbSet<InRecord> Incomes => Set<InRecord>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
