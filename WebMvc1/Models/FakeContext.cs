using Microsoft.EntityFrameworkCore;
using FoodApi.Models;

namespace WebMvc1.Models
{
    public class FakeContext : DbContext
    {
        public FakeContext(DbContextOptions<FakeContext> options)
            : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }

        public DbSet<FoodApi.Models.Food> Food { get; set; }
    }
}
