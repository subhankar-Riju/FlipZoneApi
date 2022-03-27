﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Data
{
    public class FlipzoneDbContext : DbContext
    {
        public FlipzoneDbContext(DbContextOptions<FlipzoneDbContext> options):base(options)
        {
                
        }

        public DbSet<Mobile> Mobiles { set; get; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Tablet> Tablets { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}