﻿// <auto-generated />
using Bookmarted.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookmarted.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    partial class BookStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bookmarted.Domain.Entities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<int>("Condition")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Bookmarted.Domain.Entities.BookAvailability", b =>
                {
                    b.Property<int>("BookAvailabilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookAvailabilityId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("BookAvailabilityId");

                    b.HasIndex("BookId");

                    b.HasIndex("StoreId");

                    b.ToTable("BookAvailabilities");
                });

            modelBuilder.Entity("Bookmarted.Domain.Entities.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Bookmarted.Domain.Entities.BookAvailability", b =>
                {
                    b.HasOne("Bookmarted.Domain.Entities.Book", "Book")
                        .WithMany("BookAvailabilities")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookmarted.Domain.Entities.Store", "Store")
                        .WithMany("BookAvailabilities")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Bookmarted.Domain.ValueObjects.Money", "Price", b1 =>
                        {
                            b1.Property<int>("BookAvailabilityId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Amount")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("BookAvailabilityId");

                            b1.ToTable("BookAvailabilities");

                            b1.WithOwner()
                                .HasForeignKey("BookAvailabilityId");
                        });

                    b.OwnsOne("Bookmarted.Domain.ValueObjects.Stock", "Stock", b1 =>
                        {
                            b1.Property<int>("BookAvailabilityId")
                                .HasColumnType("int");

                            b1.Property<int>("Quantity")
                                .HasColumnType("int");

                            b1.HasKey("BookAvailabilityId");

                            b1.ToTable("BookAvailabilities");

                            b1.WithOwner()
                                .HasForeignKey("BookAvailabilityId");
                        });

                    b.Navigation("Book");

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("Stock")
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Bookmarted.Domain.Entities.Book", b =>
                {
                    b.Navigation("BookAvailabilities");
                });

            modelBuilder.Entity("Bookmarted.Domain.Entities.Store", b =>
                {
                    b.Navigation("BookAvailabilities");
                });
#pragma warning restore 612, 618
        }
    }
}
