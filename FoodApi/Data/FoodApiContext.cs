using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodApi.Models;

namespace FoodApi.Data
{
    public class FoodApiContext : DbContext
    {
        public FoodApiContext (DbContextOptions<FoodApiContext> options)
            : base(options)
        {
        }

        public DbSet<FoodApi.Models.Food> Food { get; set; }
    }
}
