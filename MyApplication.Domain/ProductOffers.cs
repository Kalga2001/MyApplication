using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain
{
    public class ProductOffers : BaseEntity
    {
        public int ProductId { get; set; }
        public ICollection<Products> Products { get; set; }

        public int MaterialOptionsId { get; set; }
        public ICollection<ProductsMaterialOptions> ProductsMaterialOptions { get; set; }
        public int SizeOptionId { get; set; }
        public ICollection<ProductSizeOptions> ProductSizeOptions { get; set; }
        public decimal Price {get;set;}
    }
}
