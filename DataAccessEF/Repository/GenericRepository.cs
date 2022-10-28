using Core.IRepository;
using Core.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {

            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeASync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }
   
       
        public async Task<PagedList<T>> GetAllAsync(PagingDetails pagingDetails, Expression<Func<T, bool>> exprssion = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {

            IQueryable<T> query = _dbSet;
            if (exprssion!=null)
            {
                query = query.Where(exprssion);
            }
            if (includes != null)
            {
                foreach (var includePropery in includes)
                {
                    query = query.Include(includePropery);
                }
            }
            if (orderBy!=null)
            {
                query = orderBy(query);
            }
            return PagedList<T>.ToPagedList( query, pagingDetails.PageNumber, pagingDetails.PageSize);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);

        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> exprssion, List<string> includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                foreach (var includePropery in includes)
                {
                    query = query.Include(includePropery);
                }
            }
            return await query.FirstOrDefaultAsync(exprssion);
        }

        public async Task Delete(int id)
        {
             var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException(" Entity Not Found");
            }
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(" Entity Not Found");
            }

            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        public async Task<int> CountAsync()
        {
         
            return await _dbSet.CountAsync();

        }

    
    }
}
