using Microsoft.Identity.Client;

namespace CodingWiki.DataAccess.Repositories
{
    internal interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task Delete(int id);
        Task Save();
    }
}