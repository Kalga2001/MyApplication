using MyApplication.Domain;
using System.Linq.Expressions;

namespace MyApplication.DAL.Interface
{
    public interface IGenericRepository
    {
        Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity;
        Task<TEntity> GetByIdWithInclude<TEntity>(int id, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity;
        Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity;
        Task SaveChangesAsync();

        void Add<TEntity>(TEntity entity) where TEntity : BaseEntity;

        Task<TEntity> Delete<TEntity>(int id) where TEntity : BaseEntity;

    }
}
