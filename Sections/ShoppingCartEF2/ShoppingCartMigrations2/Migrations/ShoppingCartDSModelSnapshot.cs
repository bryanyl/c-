﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingCartEF2.Data;

#nullable disable

namespace ShoppingCartMigrations.Migrations
{
    [DbContext(typeof(ShoppingCartDS))]
    partial class ShoppingCartDSModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShoppingCartEF2.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OnLoanLibraryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("PrimaryLibraryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PurchasePrice");

                    b.HasKey("Id");

                    b.HasIndex("OnLoanLibraryId");

                    b.HasIndex("PrimaryLibraryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ShoppingCartEF2.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("CustomerBudget")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("CustomerGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ShoppingCartEF2.Entities.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LibraryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Libaries");
                });

            modelBuilder.Entity("ShoppingCartEF2.Entities.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Note_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NoteId"), 1L, 1);

                    b.Property<DateTime>("LastUpdated")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<string>("NoteText")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Score")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("UrlSmall")
                        .HasComment("The URL of the web page the note is about");

                    b.HasKey("NoteId");

                    b.ToTable("Customer_Notes");
                });

            modelBuilder.Entity("ShoppingCartEF2.Entities.Order", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageIndex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackagePrefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ShoppingCartEF2.Entities.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PartName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parts", null, t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("ShoppingCartEF2.Entities.Book", b =>
                {
                    b.HasOne("ShoppingCartEF2.Entities.Library", "OnLoanLibrary")
                        .WithMany("BooksOnLoan")
                        .HasForeignKey("OnLoanLibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingCartEF2.Entities.Library", "PrimaryLibrary")
                        .WithMany("PrimaryBooks")
                        .HasForeignKey("PrimaryLibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OnLoanLibrary");

                    b.Navigation("PrimaryLibrary");
                });

            modelBuilder.Entity("ShoppingCartEF2.Entities.Library", b =>
                {
                    b.Navigation("BooksOnLoan");

                    b.Navigation("PrimaryBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
