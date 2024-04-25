
using Microsoft.EntityFrameworkCore;
using UserMVC5App.Models;

namespace UserMVC5App.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public readonly UsersMvc5dbContext? _context;
        private readonly DbSet<T>? _dbSet;

        protected BaseRepository(UsersMvc5dbContext? context)
        {
            _context = context;
            _dbSet = _context!.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            T? existing = await _dbSet.FindAsync(id);
            if (existing is not null)
            {
                _dbSet.Remove(existing);
                return true;
            }
            return false;
        }

        public virtual async Task<T?> GeatAsync(int id)
        {
            var entity = await _dbSet!.FindAsync(id);
            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _dbSet!.ToListAsync();
            return entities;
        }

        public virtual async Task<int> GetCountAsync()
        {
            var count = await _dbSet!.CountAsync();
            return count;
        }

        public virtual void UpdateAsync(T entity)
        {
            _dbSet!.Attach(entity);
            _context!.Entry(entity).State = EntityState.Modified;
        }
    }
}
