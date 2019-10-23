using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Core;

namespace Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options)
            : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }


    }
}
