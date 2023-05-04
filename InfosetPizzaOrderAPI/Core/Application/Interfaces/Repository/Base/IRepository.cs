using Domain.Base;
using System.Linq.Expressions;

namespace Application.Interfaces.Repository.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<bool> AddAsync(T entity);
        Task<int> SaveAsync();
        Task<List<T>> GetByFilter(Expression<Func<T, bool>> filterExpression);
    }
}
