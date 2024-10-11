// See https://aka.ms/new-console-template for more information
using CodingWiki.DataAccess.Data;
using CodingWiki.DataAccess.Migrations;
using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

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
    Title = "Arquitectura Limpia",
    ISBN = "57889UU67",
    Price = 10.93m,
    PublisherId = 1
};

//AddBook(book);
//UpdateBook();
//Console.WriteLine();
//GetAllBooks();
//Console.WriteLine();

//Book firstBook = GetFirstBook();
//PrintBookTitleAndISBN(firstBook);

Book GetFirstBook()
{
    using ApplicationDbContext context = new();
    var books = context.Books.Skip(0).Take(2);

    foreach (var book in books)
    {
        PrintBookTitleAndISBN(book);
    }
    Console.WriteLine();

    books = context.Books.Skip(4).Take(1);

    foreach (var book in books)
    {
        PrintBookTitleAndISBN(book);
    }
    Console.WriteLine();

    if (books.FirstOrDefault() != null)
        return books.FirstOrDefault();

    return new Book();
}

void UpdateBook()
{
    using var context = new ApplicationDbContext();
    var books = context.Books.Find(8);
    if (book == null) return;
    
    books.ISBN = "777";
    context.SaveChanges();   
}

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
        PrintBookTitleAndISBN(book);
    }
}

void PrintBookTitleAndISBN(Book book)
{
    Console.WriteLine($"{book.Title} - {book.ISBN}");
}