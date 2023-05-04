using Application.Interfaces.Repository.Base;
using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.DataContext;
using System.Linq.Expressions;

namespace Persistence.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        readonly InfosetDbContext _dbContext;
        public Repository(InfosetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private DbSet<T> _dbSet
        {
            get
            {
                return _dbContext.Set<T>();
            }
            set { _dbSet = _dbContext.Set<T>(); }
        }

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry entry = await _dbSet.AddAsync(entity);
            return entry.State == EntityState.Added;
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }
        public async Task<List<T>> GetByFilter(Expression<Func<T, bool>> filterExpression) => await _dbSet.Where(filterExpression).ToListAsync();
        public Task<int> SaveAsync() => _dbContext.SaveChangesAsync();

    }
}
