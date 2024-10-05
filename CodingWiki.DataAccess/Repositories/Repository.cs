using CodingWiki.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.DataAccess.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
            using ApplicationDbContext context = new();
            var list = await context.AddAsync(entity);

            return await Task.FromResult(list.Entity);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
