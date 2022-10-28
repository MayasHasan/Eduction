using Core.Paging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepository
{
     public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<PagedList<T>> GetAllAsync(PagingDetails pagingDetails,
            Expression<Func<T, bool>> exprssion = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null);
        Task<T> GetAsync(Expression<Func<T, bool>> exprssion, List<string> includes = null);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeASync(IEnumerable<T>entities);
        Task Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        T Update(T entity);
        Task<int> CountAsync();


    }
}
