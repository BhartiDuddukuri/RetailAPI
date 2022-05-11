﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RetailAPI.Models;

namespace RetailAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220510074543_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RetailAPI.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Fruits"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Vegetables"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Poultry"
                        });
                });

            modelBuilder.Entity("RetailAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("StatusID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            Barcode = "11111",
                            CategoryID = 1,
                            Description = "Apples",
                            ProductName = "Apples",
                            StatusID = 1,
                            Weight = 10
                        },
                        new
                        {
                            ProductID = 2,
                            Barcode = "22222",
                            CategoryID = 1,
                            Description = "Oranges",
                            ProductName = "Oranges",
                            StatusID = 2,
                            Weight = 12
                        },
                        new
                        {
                            ProductID = 3,
                            Barcode = "33333",
                            CategoryID = 1,
                            Description = "Grapes",
                            ProductName = "Grapes",
                            StatusID = 3,
                            Weight = 2
                        },
                        new
                        {
                            ProductID = 4,
                            Barcode = "44444",
                            CategoryID = 2,
                            Description = "Carrots",
                            ProductName = "Carrots",
                            StatusID = 1,
                            Weight = 5
                        },
                        new
                        {
                            ProductID = 5,
                            Barcode = "55555",
                            CategoryID = 2,
                            Description = "Cucumber",
                            ProductName = "Cucumber",
                            StatusID = 2,
                            Weight = 15
                        },
                        new
                        {
                            ProductID = 6,
                            Barcode = "66666",
                            CategoryID = 3,
                            Description = "Eggs",
                            ProductName = "Eggs",
                            StatusID = 1,
                            Weight = 20
                        },
                        new
                        {
                            ProductID = 7,
                            Barcode = "77777",
                            CategoryID = 3,
                            Description = "Meat",
                            ProductName = "Meat",
                            StatusID = 2,
                            Weight = 18
                        });
                });

            modelBuilder.Entity("RetailAPI.Models.Status", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusID");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusID = 1,
                            StatusName = "Sold"
                        },
                        new
                        {
                            StatusID = 2,
                            StatusName = "InStock"
                        },
                        new
                        {
                            StatusID = 3,
                            StatusName = "Damaged"
                        });
                });

            modelBuilder.Entity("RetailAPI.Models.Product", b =>
                {
                    b.HasOne("RetailAPI.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetailAPI.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
