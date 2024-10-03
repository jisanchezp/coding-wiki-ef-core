using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        // rename to FluentBookDetails
        public DbSet<FluentBookDetail> BookDetail_Fluent { get; set; }
        public DbSet<FluentBook> FluentBooks { get; set; }
        public DbSet<FluentAuthor> FluentAuthors { get; set; }
        public DbSet<FluentPublisher> FluentPublishers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=CodingWiki;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FluentBookDetail>().ToTable("FluentBookDetails");
            modelBuilder.Entity<FluentBookDetail>().HasKey(p => p.BookDetail_Id);
            modelBuilder.Entity<FluentBookDetail>().Property(p => p.NumberOfChapters).HasColumnName("NoOfChapters");
            modelBuilder.Entity<FluentBookDetail>().Property(p => p.NumberOfChapters).IsRequired();
            modelBuilder.Entity<FluentBookDetail>()
                .HasOne(p => p.Book).WithOne(p => p.BookDetail)
                .HasForeignKey<FluentBookDetail>(p => p.BookId);

            modelBuilder.Entity<FluentBook>().HasKey(p => p.Book_Id);
            modelBuilder.Entity<FluentBook>()
                .Property(p => p.ISBN)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<FluentBook>().Ignore(p => p.PriceRange);
            modelBuilder.Entity<FluentBook>()
                .HasOne(p => p.Publisher).WithMany(p => p.Books)
                .HasForeignKey(p => p.PublisherId);

            modelBuilder.Entity<FluentAuthor>().HasKey(p => p.Author_Id);
            modelBuilder.Entity<FluentAuthor>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<FluentAuthor>().Property(p => p.LastName).IsRequired();
            modelBuilder.Entity<FluentAuthor>().Property(p => p.BirthDate).HasColumnType("datetime2");
            modelBuilder.Entity<FluentAuthor>().Ignore(p => p.FullName);

            modelBuilder.Entity<FluentPublisher>().HasKey(p => p.Publisher_Id);
            modelBuilder.Entity<FluentPublisher>().Property(p => p.Name).IsRequired();




            modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(10,6);

            modelBuilder.Entity<BookAuthorMap>().HasKey(bam => new { bam.BookId, bam.AuthorId });

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, ISBN = "32434JHG", Title = "Little Prairy", Price = 32.5m, PublisherId = 2 },
                new Book { Id = 2, ISBN = "34HJ4GH5", Title = "Chaos: The birth of a new science", Price = 50.80m, PublisherId = 3 },
                new Book { Id = 3, ISBN = "45JKKJJK", Title = "The Little Prince", Price = 44.99m, PublisherId = 2 }
            );

            List<Book> moreBooks = new()
            {
                new Book { Id = 4, ISBN = "2347H3HG", Title = "The Batman", Price = 42.5m, PublisherId = 1 },
                new Book { Id = 5, ISBN = "734HJH25", Title = "Fortune of Time", Price = 32.67m, PublisherId = 3 },
                new Book { Id = 6, ISBN = "621363KJ", Title = "Spider without Duty", Price = 23.39m, PublisherId = 2 }
            };

            modelBuilder.Entity<Book>().HasData(moreBooks);

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "NO DATA", Location = "NA" },
                new Publisher { Id = 2, Name = "Penguin andom House", Location = "United States" },
                new Publisher { Id = 3, Name = "Anagrama", Location = "España" }
            );
        }
    }
}
