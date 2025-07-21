using KairaCQRSMediator.DataAccess.Entities;
using System.Linq.Expressions;

namespace KairaCQRSMediator.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAllAsync(Expression<Func<T,object>>? include=null);
        Task<List<Product>> GetProductsByFilterAsync(Expression<Func<Product, bool>> filter);
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
