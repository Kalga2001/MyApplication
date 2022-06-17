using MyApplication.Common.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.BLL.Interface
{
    public interface IProductService
    {
        Task<ProductDto> GetProduct(int id);

        Task<ProductDto> CreateProduct(ProductForUpdateDto productForUpdateDto);

        Task UpdateProduct(int id, ProductForUpdateDto productDto);

        Task DeleteProduct(int id);

        Task<IEnumerable<ProductCollectionDto>> GetAllProducts();
    }
}
