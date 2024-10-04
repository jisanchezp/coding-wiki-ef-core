// See https://aka.ms/new-console-template for more information
using CodingWiki.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Coding Wiki JS!");
Console.WriteLine("JS does not stand for JavaScript ;)");

using ApplicationDbContext context = new();
context.Database.EnsureCreated();

if (context.Database.GetPendingMigrations().Any())
{
    context.Database.Migrate();
}