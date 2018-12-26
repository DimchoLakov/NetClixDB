using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetPhlixDB.Data;
using NetPhlixDB.Services.Repositories.Contracts;

namespace NetPhlixDB.Services.Repositories
{
    public class DbRepository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly NetPhlixDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public DbRepository(NetPhlixDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = this._dbContext.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await this._dbSet.AddAsync(entity);
        }

        public IQueryable<TEntity> All()
        {
            return this._dbSet;
        }

        public void Delete(TEntity entity)
        {
            this._dbSet.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this._dbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            this._dbSet.Update(entity);
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}
