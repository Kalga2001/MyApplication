using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain
{
    public class ProductSizeOptions : BaseEntity
    {
        public string Quantity { get; set; }
        public ICollection<ProductOffers> ProductOffers { get; set; }

        public double Height { get; set; }
        public double Width { get; set; }

        public int UnitsId { get; set; }
        public ICollection<Units> Units { get; set; }
    }
}
