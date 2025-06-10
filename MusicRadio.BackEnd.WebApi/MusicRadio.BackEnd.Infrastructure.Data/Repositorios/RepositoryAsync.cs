using MusicRadio.BackEnd.Infrastructure.Framework.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicRadio.BackEnd.Infrastructure.Data.Repositorios
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        public DbContext context;
        public readonly DbSet<TEntity> dbSet;
        public RepositoryAsync(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }
        public virtual Task UpdateAsync(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
        public virtual Task DeleteAsync(TEntity entity)
        {
            dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null) dbSet.Remove(entity);
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var items = await dbSet.Where(predicate).ToListAsync();
            dbSet.RemoveRange(items);
        }
        public virtual async Task<TEntity?> GetByIdAsync(params object[] id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet
                  .Where(predicate)
                  .ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }


        public virtual async Task<List<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null) query = query.Where(filter);

            foreach (var include in includeProperties.Split(
                         new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(include);
            }

            return await (orderBy != null ? orderBy(query) : query).ToListAsync();
        }
        public Task<int> CommitAsync() => context.SaveChangesAsync();
        
    }
    
    
}
