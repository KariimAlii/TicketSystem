using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Application.Contracts.Persistance.Context;
using TicketSystem.Application.Contracts.Persistance.Repositories;
using TicketSystem.Persistance.Context;

namespace TicketSystem.Persistance.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TicketAppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(TicketAppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.DBSaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.DBSaveChangesAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return await InitializeQuery(includes).FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetAllWhereQueryable(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return InitializeQuery(includes).Where(predicate);
        }
        
        public IQueryable<T> GetAllWhereQueryableWithoutCondition(params Expression<Func<T, object>>[] includes)
        {
            return InitializeQuery(includes);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<List<T>> ListAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<List<T>> ListAllAsync(Expression<Func<T, object>> orderBy = null, int page = 1, int pageSize = 5)
        {
            var query = _dbSet.AsQueryable();
            if (orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }
            if (pageSize > 0)
            {
                query = query.Skip((page - 1) * pageSize).Take(pageSize);
            }
            return await query.ToListAsync();
        }
        public async Task<List<T>> ListAllAsync(Expression<Func<T, object>> orderBy = null, int page = 1, int pageSize = 5 , params Expression<Func<T, object>>[] includes)
        {
            var query = InitializeQuery(includes);
            if (orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }
            if (pageSize > 0)
            {
                query = query.Skip((page - 1) * pageSize).Take(pageSize);
            }
            return await query.ToListAsync();
        }


        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.DBSaveChangesAsync();
        }
        private IQueryable<T> InitializeQuery(params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }

        
    }
}
