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
        
        public BookService(ApplicationDbContext context)
        {
            _bookRepository = new Repository<Book>(context);
        }

        public async Task<Book> Create(Book entity)
        {
            var book = await _bookRepository.Create(entity);

            if (book != null)
            {
                Console.WriteLine($"[{book.Id}] {book.Title} has been created! (ISBN:{book.ISBN}");
                return book;
            }

            return entity;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAllWithSvn()
        {
            var books = _bookRepository.GetAll();
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
