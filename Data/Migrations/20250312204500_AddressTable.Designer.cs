﻿// <auto-generated />
using EF_Core_04_Join_Demo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_Core_04_Join_Demo.Data.Migrations
{
    [DbContext(typeof(CompanyDBContext))]
    [Migration("20250312204500_AddressTable")]
    partial class AddressTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF_Core_04_Join_Demo.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId")
                        .IsUnique()
                        .HasFilter("[ManagerId] IS NOT NULL");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EF_Core_04_Join_Demo.Models.Empolyee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("DeparmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DeparmentId");

                    b.ToTable("Empolyes");
                });

            modelBuilder.Entity("EF_Core_04_Join_Demo.Models.Department", b =>
                {
                    b.HasOne("EF_Core_04_Join_Demo.Models.Empolyee", "Manager")
                        .WithOne("Manage")
                        .HasForeignKey("EF_Core_04_Join_Demo.Models.Department", "ManagerId");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("EF_Core_04_Join_Demo.Models.Empolyee", b =>
                {
                    b.HasOne("EF_Core_04_Join_Demo.Models.Department", "Department")
                        .WithMany("empolyees")
                        .HasForeignKey("DeparmentId");

                    b.OwnsOne("EF_Core_04_Join_Demo.Models.Address", "DetailedAddress", b1 =>
                        {
                            b1.Property<int>("EmpolyeeId")
                                .HasColumnType("int");

                            b1.Property<int?>("BlocNum")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("EmpolyeeId");

                            b1.ToTable("Empolyes");

                            b1.WithOwner()
                                .HasForeignKey("EmpolyeeId");
                        });

                    b.Navigation("Department");

                    b.Navigation("DetailedAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("EF_Core_04_Join_Demo.Models.Department", b =>
                {
                    b.Navigation("empolyees");
                });

            modelBuilder.Entity("EF_Core_04_Join_Demo.Models.Empolyee", b =>
                {
                    b.Navigation("Manage");
                });
#pragma warning restore 612, 618
        }
    }
}
