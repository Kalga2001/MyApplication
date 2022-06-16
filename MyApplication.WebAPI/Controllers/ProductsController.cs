using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApplication.BLL.Services;
using MyApplication.DAL.Interface;
using MyApplication.Domain;
using Newtonsoft.Json;

namespace MyApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Products> _product;
        private readonly ProductServices _service;

        public ProductsController(IGenericRepository<Products> product, ProductServices service)
        {
            _service = service;
            _product= product;

        }
        //Add Product 
        [HttpPost("AddProduct")]
        public async Task<Object> AddProduct([FromBody] Products product)
        {
            try
            {
                await _service.AddProduct(product);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete Product 
        [HttpDelete("DeleteProduct")]
        public async Task DeleteProduct(int id)
        {
           await _service.DeleteProduct(id);
        }
        //Update Product
        [HttpPut("UpdateProduct")]
        public bool UpdateProduct(Products product)
        {
            try
            {
                _service.UpdateProduct(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //GET All Products by Name  
        [HttpGet("GetAllProductsByName")]
        public Object GetAllProductsByName(string UserEmail)
        {
            var data = _service.GetProductByName(UserEmail);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All Products  
        [HttpGet("GetAllProducts")]
        public Object GetAllProducts()
        {
            var data = _service.GetAllProducts();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}

