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
await DeleteBook();



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

async Task DeleteBook()
{
    using ApplicationDbContext context = new();
    var book = await context.Books.FindAsync(8);

    if (book == null) return;

    context.Books.Remove(book);
    await context.SaveChangesAsync();
}

async Task UpdateBook()
{
    using var context = new ApplicationDbContext();
    var books = await context.Books.FindAsync(8);
    if (book == null) return;
    
    books.ISBN = "777";
    await context.SaveChangesAsync();   
}

async Task AddBook(Book book)
{
    using ApplicationDbContext context = new();
    var books = await context.Books.AddAsync(book);
    await context.SaveChangesAsync();
}

async Task GetAllBooks()
{
    using ApplicationDbContext context = new();
    var books = await context.Books.ToListAsync();

    foreach (var book in books)
    {
        PrintBookTitleAndISBN(book);
    }
}

void PrintBookTitleAndISBN(Book book)
{
    Console.WriteLine($"{book.Title} - {book.ISBN}");
}