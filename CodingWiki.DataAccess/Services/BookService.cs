using CodingWiki.DataAccess.Data;
using CodingWiki.DataAccess.Repositories;
using CodingWiki.Model.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.DataAccess.Services
{
    public class BookService
    {
        private ApplicationDbContext _context;
        private readonly IRepository<Book> _bookRepository;
        public const int ISBN_LENGTH = 8;
        public BookService(ApplicationDbContext context)
        {
            _bookRepository = new BookRepository(context);
        }

        public async Task<Book> Create(Book entity)
        {
            var book = await _bookRepository.Create(entity);

            if (book != null)
            {
                Console.WriteLine($"[{book.Id}] {book.Title} has been created! (ISBN:{book.ISBN})");
                return book;
            }

            return entity;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Book>> GetAll()
        {
            var books = await _bookRepository.GetAll();

            if (books.Any() == false)
            {
                Console.WriteLine($"No hay libros.");
                return new List<Book>();
            }

            return books;
        }

        public void DisplayAllTitlesWithISBN(List<Book> books)
        {
            Console.WriteLine();
            Console.WriteLine("***************************");
            Console.WriteLine(" Displaying all titles with ISBN");
            Console.WriteLine("***************************");
            Console.WriteLine();

            var longestTitleLength = books.OrderByDescending(books => books.Title.Length).FirstOrDefault().Title.Length;            

            foreach (var book in books)
            {
                Console.WriteLine(String.Format($"{{0,-{longestTitleLength}}} - (ISBN: {{1,-{ISBN_LENGTH}}})", book.Title, book.ISBN));
            }

            Console.WriteLine();
        }

        public Task<Book> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task<Book> Update(int id, Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
