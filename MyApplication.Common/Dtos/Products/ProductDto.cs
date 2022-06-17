using MyApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Common.Dtos.Products
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public ICollection<ProductOffers> ProductOffers { get; set; }
        public int ProductId { get; set; }
    }
}
