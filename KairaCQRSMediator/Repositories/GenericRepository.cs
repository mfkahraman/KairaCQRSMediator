using KairaCQRSMediator.DataAccess.Context;
using KairaCQRSMediator.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace KairaCQRSMediator.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly KairaContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(KairaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _table = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _table.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id)
            ?? throw new KeyNotFoundException($"Entity with id {id} not found.");
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
