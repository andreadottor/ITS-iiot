using Microsoft.EntityFrameworkCore;
using Northwind.Dottor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Dottor.Data
{
    public class NorthwindContext : DbContext
    {

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
