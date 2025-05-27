using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicRadio.BackEnd.Infrastructure.Framework.RepositoryPattern
{
    public interface IAsyncRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entityList);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(Expression<Func<T, bool>> where);

        Task<T> GetByIdAsync(params object[] id);
        Task<T> GetAsync(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        Task<IEnumerable<T>> GetQueryableAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllQueryableAsync();

        Task<int> CommitAsync();

        Task ExecuteSqlCommandAsync(string procedureName, object parameters);
        Task<DataSet> ExecuteStoreProcedureAsync(string sqlQuery, List<DbParameter> parameters);
        Task<IEnumerable<TEntityVO>> ExecuteStoreProcedureAsync<TEntityVO>(string procedureName, object parameters);
    }
}
