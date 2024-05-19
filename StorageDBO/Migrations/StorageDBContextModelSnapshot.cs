﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StorageDBO.Data;

#nullable disable

namespace StorageDBO.Migrations
{
    [DbContext(typeof(StorageDBContext))]
    partial class StorageDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StorageDBO.Entities.Articul", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArticulGroupID")
                        .HasColumnType("int");

                    b.Property<string>("ArticulImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticulName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticulSellerCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArticulGroupID");

                    b.ToTable("Articuls");
                });

            modelBuilder.Entity("StorageDBO.Entities.ArticulGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ArticulGroups");
                });

            modelBuilder.Entity("StorageDBO.Entities.InRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("ChangeDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("StorageDBO.Entities.InRecordCount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticulId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("RecordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticulId");

                    b.HasIndex("RecordId", "ArticulId");

                    b.ToTable("InRecords", (string)null);
                });

            modelBuilder.Entity("StorageDBO.Entities.OutRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("ChangeDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("StorageDBO.Entities.OutRecordCount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticulId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("RecordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticulId");

                    b.HasIndex("RecordId", "ArticulId");

                    b.ToTable("OutRecords", (string)null);
                });

            modelBuilder.Entity("StorageDBO.Entities.Articul", b =>
                {
                    b.HasOne("StorageDBO.Entities.ArticulGroup", "ArticulGroup")
                        .WithMany("Articuls")
                        .HasForeignKey("ArticulGroupID");

                    b.Navigation("ArticulGroup");
                });

            modelBuilder.Entity("StorageDBO.Entities.InRecordCount", b =>
                {
                    b.HasOne("StorageDBO.Entities.Articul", "Articul")
                        .WithMany()
                        .HasForeignKey("ArticulId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StorageDBO.Entities.InRecord", "Record")
                        .WithMany("Records")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articul");

                    b.Navigation("Record");
                });

            modelBuilder.Entity("StorageDBO.Entities.OutRecordCount", b =>
                {
                    b.HasOne("StorageDBO.Entities.Articul", "Articul")
                        .WithMany()
                        .HasForeignKey("ArticulId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StorageDBO.Entities.OutRecord", "Record")
                        .WithMany("Records")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articul");

                    b.Navigation("Record");
                });

            modelBuilder.Entity("StorageDBO.Entities.ArticulGroup", b =>
                {
                    b.Navigation("Articuls");
                });

            modelBuilder.Entity("StorageDBO.Entities.InRecord", b =>
                {
                    b.Navigation("Records");
                });

            modelBuilder.Entity("StorageDBO.Entities.OutRecord", b =>
                {
                    b.Navigation("Records");
                });
#pragma warning restore 612, 618
        }
    }
}
