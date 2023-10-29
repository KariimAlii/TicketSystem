using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Application.Contracts.Persistance.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAllAsync(Expression<Func<T, object>> orderBy = null, int page = 1, int pageSize = 10, params Expression<Func<T, object>>[] includes);
        Task<List<T>> ListAllAsync(Expression<Func<T, object>> orderBy = null, int page = 1, int pageSize = 10);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAllWhereQueryable(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAllWhereQueryableWithoutCondition(params Expression<Func<T, object>>[] includes);

    }
}
