using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SisWebSalesMVC.Models
{
    public class SisWebSalesMVCContext : DbContext
    {
        public SisWebSalesMVCContext (DbContextOptions<SisWebSalesMVCContext> options)
            : base(options)
        {
        }

        public DbSet<SisWebSalesMVC.Models.Department> Department { get; set; }
    }
}
