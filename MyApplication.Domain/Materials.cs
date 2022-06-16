using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain
{
    public class Materials : BaseEntity
    {
        public string MaterialsName { get; set; }

        public ICollection<ProductsMaterialOptions> ProductsMaterialOptions { get; set; }
    }
}
