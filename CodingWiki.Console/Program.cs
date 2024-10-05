// See https://aka.ms/new-console-template for more information
using CodingWiki.DataAccess.Data;
using CodingWiki.DataAccess.Repositories;
using CodingWiki.DataAccess.Services;
using CodingWiki.Model.Models;

Console.WriteLine("Hello, Coding Wiki JS!");
Console.WriteLine("JS does not stand for JavaScript ;)");

ApplicationDbContext context = new ApplicationDbContext();

var bookService = new BookService(context);
var allBooks = await bookService.GetAll();
bookService.DisplayAllTitlesWithISBN(allBooks);