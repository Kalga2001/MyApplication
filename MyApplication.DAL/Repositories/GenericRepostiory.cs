using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApplication.DAL.Interface;
using MyApplication.Domain;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace MyApplication.DAL.Repositories
{
    public class GenericRepostiory: IGenericRepository
    {
        private readonly MyApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenericRepostiory(MyApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity
        {
            return await _context.FindAsync<TEntity>(id);
        }

        public async Task<TEntity> GetByIdWithInclude<TEntity>(int id, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity
        {
            var query = IncludeProperties(includeProperties);
            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
                 _context
                .Set<TEntity>()
                .Add(entity);
        }

        public async Task<TEntity> Delete<TEntity>(int id) where TEntity : BaseEntity
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                throw new ValidationException($"Object of type {typeof(TEntity)} with id {id} not found");
            }

            _context.Set<TEntity>().Remove(entity);

            return entity;
        }


        private IQueryable<TEntity> IncludeProperties<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity
        {
            IQueryable<TEntity> entities = _context.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }
            return entities;
        }
    }
}


