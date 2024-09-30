﻿// <auto-generated />
using CodingWiki.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240930202455_AddBooksSeed")]
    partial class AddBooksSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodingWiki.Model.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 6)
                        .HasColumnType("decimal(10,6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ISBN = "32434JHG",
                            Price = 32.5m,
                            Title = "Little Prairy"
                        },
                        new
                        {
                            Id = 2,
                            ISBN = "34HJ4GH5",
                            Price = 50.80m,
                            Title = "Chaos: The birth of a new science"
                        },
                        new
                        {
                            Id = 3,
                            ISBN = "45JKKJJK",
                            Price = 44.99m,
                            Title = "The Little Prince"
                        },
                        new
                        {
                            Id = 4,
                            ISBN = "2347H3HG",
                            Price = 42.5m,
                            Title = "The Batman"
                        },
                        new
                        {
                            Id = 5,
                            ISBN = "734HJH25",
                            Price = 32.67m,
                            Title = "Fortune of Time"
                        },
                        new
                        {
                            Id = 6,
                            ISBN = "621363KJ",
                            Price = 23.39m,
                            Title = "Spider without Duty"
                        });
                });

            modelBuilder.Entity("CodingWiki.Model.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}
