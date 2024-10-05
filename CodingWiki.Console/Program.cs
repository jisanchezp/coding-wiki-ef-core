// See https://aka.ms/new-console-template for more information
using CodingWiki.DataAccess.Data;
using CodingWiki.DataAccess.Migrations;
using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Coding Wiki JS!");
Console.WriteLine("JS does not stand for JavaScript ;)");

//using ApplicationDbContext context = new();
//context.Database.EnsureCreated();

//if (context.Database.GetPendingMigrations().Any())
//{
//    context.Database.Migrate();
//}
Book book = new Book()
{
    Title = "Código Limpio",
    ISBN = "56HH6667",
    Price = 10.93m,
    PublisherId = 1
};

AddBook(book);

GetAllBooks();

void AddBook(Book book)
{
    using ApplicationDbContext context = new();
    var books = context.Books.Add(book);
    context.SaveChanges();
}

void GetAllBooks()
{
    using ApplicationDbContext context = new();
    var books = context.Books.ToList();

    foreach (var book in books)
    {
        Console.WriteLine($"{book.Title} - {book.ISBN}");
    }
}