using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityFramework.Repositories
{
    public abstract class EntityFrameworkBaseRepository<TEntity> : IEntityFrameworkBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EntityFrameworkBaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(int pageSize, int pageNumber)
        {
            IQueryable<TEntity> query = _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking();
            return await Task.FromResult(query);
        }
        public async Task<IQueryable<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> condition, int pageSize, int pageNumber)
        {
            var query = _dbSet.Where(condition).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking();
            return await Task.FromResult(query);
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
