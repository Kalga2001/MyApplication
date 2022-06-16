using MyApplication.Domain;
using System.Linq.Expressions;

namespace MyApplication.DAL.Interface
{
    public interface IGenericRepository<TEntity>
    {
        Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity;

        IEnumerable<TEntity> GetAll();

        Task<TEntity> Add<TEntity>(TEntity entity) where TEntity : BaseEntity;

        Task<TEntity> Delete<TEntity>(int id) where TEntity : BaseEntity;

        void Update<TEntity>(TEntity entity) where TEntity:BaseEntity;
    }
}
