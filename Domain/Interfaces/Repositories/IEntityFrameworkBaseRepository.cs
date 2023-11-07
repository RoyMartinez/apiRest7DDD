using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IEntityFrameworkBaseRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAllAsync(int pageSize,int pageNumber);
        Task<IQueryable<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> condition, int pageSize, int pageNumber);
        Task<TEntity?> GetByIdAsync(Guid id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}
