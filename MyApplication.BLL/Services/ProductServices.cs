using MyApplication.DAL.Interface;
using MyApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.BLL.Services
{
   public class ProductServices
    {
        private readonly IGenericRepository<Products> _product;

        public ProductServices(IGenericRepository<Products> product)
        {
            _product = product;
        }
        //Get product by id
        public IEnumerable<Products> GetProductById(int Id)
        {
            return _product.GetAll().Where(x => x.ProductId == Id).ToList();
        }
        //Get all products
        public IEnumerable<Products> GetAllProducts()
        {
            try
            {
                return _product.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Find product by name
        public Products GetProductByName(string ProductName)
        {
            return _product.GetAll().Where(x => x.ProductName == ProductName).FirstOrDefault();
        }
        //Add Product
        public async Task<Products> AddProduct(Products Product)
        {
            return await _product.Add(Product);
        }
        //Delete Product   
        public async Task DeleteProduct(int id)
        {
            await _product.Delete<Products>(id);

        }
        //Update Product Details  
        public bool UpdateProduct(Products product)
        {
            try
            {
                var DataList = _product.GetAll().Where(x => x.ProductId!= 0).ToList();
                foreach (var item in DataList)
                {
                    _product.Update(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}

