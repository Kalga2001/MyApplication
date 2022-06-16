using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApplication.DAL.Interface;
using MyApplication.Domain;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace MyApplication.DAL.Repositories
{
    public class ProductRepository: IGenericRepository<Products>
    {
        private readonly MyApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MyApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Products> GetById<Products>(int id) where Products : BaseEntity
        {
            return await _context.FindAsync<Products>(id);
        }


        public async Task<Products> Add<Products>(Products products) where Products : BaseEntity
        {
            var entity = await _context.Set<Products>().FindAsync(products);
            _context.Set<Products>().AddAsync(entity);
            return entity;
        }

        public async Task<Products> Delete<Products>(int id) where Products : BaseEntity
        {
            var entity = await _context.Set<Products>().FindAsync(id);
            if (entity == null)
            {
                throw new ValidationException($"Object of type {typeof(Products)} with id {id} not found");
            }

            _context.Set<Products>().Remove(entity);
            return entity;
        }


        private IQueryable<Products> IncludeProperties<Products>(params Expression<Func<Products, object>>[] includeProperties) where Products : BaseEntity
        {
            IQueryable<Products> entities = _context.Set<Products>();
            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }
            return entities;
        }

        public void Update <Products>(Products products) where Products:BaseEntity
        {
            _context.Set<Products>().Update(products);
            _context.SaveChangesAsync();

        }

        public IEnumerable<Products> GetAll()
        {
                try
                {
                    return _context.Products.Where(x => x.Id == 0).ToList();
                }
                catch (Exception ee)
                {
                    throw;
                }
        }
    }
}


