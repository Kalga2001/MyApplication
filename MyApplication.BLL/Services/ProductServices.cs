using AutoMapper;
using MyApplication.BLL.Interface;
using MyApplication.Common.Dtos.Products;
using MyApplication.DAL.Interface;
using MyApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.BLL.Services
{
   public class ProductServices:IProductService
    {
        private readonly IGenericRepository _repository;
        private readonly IMapper _mapper;

        public ProductServices(IGenericRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var product = await _repository.GetByIdWithInclude<Products>(id, product => product.ProductOffers);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task<ProductDto> CreateProduct(ProductForUpdateDto productForUpdateDto)
        {
            var product = _mapper.Map<Products>(productForUpdateDto);
            _repository.Add(product);
            await _repository.SaveChangesAsync();

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task UpdateProduct(int id, ProductForUpdateDto productDto)
        {
            var product = await _repository.GetById<Products>(id);
            _mapper.Map(productDto, product);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            await _repository.Delete<Products>(id);
            await _repository.SaveChangesAsync();
        }
        public async Task<IEnumerable<ProductCollectionDto>> GetAllProducts()
        {
            var productList = await _repository.GetAll<Products>();
            var productDtoList = _mapper.Map<List<ProductCollectionDto>>(productList);
            return productDtoList;
        }
    }

}

