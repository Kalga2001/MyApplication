using Microsoft.EntityFrameworkCore;
using MyApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.DAL
{
         public class MyApplicationDbContext :DbContext
        {
            public MyApplicationDbContext(DbContextOptions<MyApplicationDbContext> options) : base(options)
            {

            }

           public DbSet<Materials> Materials { get; set; }
           public DbSet<Products> Products { get; set; }
           public DbSet<ProductOffers> ProductOffers { get; set; }
           public DbSet<Units> Units { get; set; }

        }
}
