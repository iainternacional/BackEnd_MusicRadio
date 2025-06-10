using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicRadio.BackEnd.Infrastructure.Framework.RepositoryPattern
{
    public interface IRepositoryAsync<T> where T : class
    {
        /* ----------- CREATE ----------- */
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entityList);

        /* ----------- UPDATE ----------- */
        Task UpdateAsync(T entity);

        /* ----------- DELETE ----------- */
        Task DeleteAsync(T entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(Expression<Func<T, bool>> where);

        /* ----------- READ ----------- */
        Task<T> GetByIdAsync(params object[] id);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> where);

        Task<List<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        Task<List<T>> GetAllAsync();

        /* ----------- UNIT OF WORK ----------- */
        Task<int> CommitAsync();

    }
}
