using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.DataAccess.Repositories
{
    internal class BookRepository : IRepository<Book>
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> Create(Book entity)
        {
            var book = await _context.Books.AddAsync(entity);
            
            return await Task.FromResult(book.Entity);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Book>> GetAll()
        {
            var books = _context.Books.ToList();
            return await Task.FromResult(books);
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
