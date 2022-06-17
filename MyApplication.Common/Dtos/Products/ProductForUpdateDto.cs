using MyApplication.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Common.Dtos.Products
{
    public class ProductForUpdateDto
    {
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string ProductName { get; set; }

        [Required]
        public ICollection<ProductOffers> ProductOffers { get; set; }
        [Key]
        public int ProductId { get; set; }
    }
}
