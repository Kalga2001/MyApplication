using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain
{
   public class ProductsMaterialOptions: BaseEntity
    {
        public ICollection<ProductOffers> ProductOffers { get; set; }
        public string Quantity { get; set; }

        public int MaterialId { get; set; }
        public ICollection<Materials> Materials { get; set; }

    }
}
