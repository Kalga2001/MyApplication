using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApplication.BLL.Services;
using MyApplication.Common.Dtos.Products;
using MyApplication.DAL.Interface;
using MyApplication.Domain;
using Newtonsoft.Json;

namespace MyApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository _product;
        private readonly ProductServices _service;

        public ProductsController(IGenericRepository product, ProductServices service)
        {
            _service = service;
            _product= product;

        }
        [HttpGet("{id}")]
        public async Task<ProductDto> GetProduct(int id)
        {
            var productDto = await _service.GetProduct(id);
            return productDto;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductForUpdateDto productForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productDto = await _service.CreateProduct(productForUpdateDto);

            return CreatedAtAction(nameof(GetProduct), new { id = productDto.ProductId }, productDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductForUpdateDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.UpdateProduct(id, productDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(int id)
        {
            await _service.DeleteProduct(id);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductCollectionDto>> GetAllProducts()
        {
            var products = await _service.GetAllProducts();
            return products;
        }
    }
}


