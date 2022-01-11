using FoodApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace FoodApi.Models
{
    public static class SeedData
    {
        public static void SeedFood(IServiceProvider serviceProvider)
        {
            using (var context = new FoodApiContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FoodApiContext>>()))
            {
                if (context.Food.Any())
                {
                    return;
                }

                context.Food.AddRange(
                        new Food
                        {
                            Name = "Miód",
                            Price = 12.45M,
                            Stock = 134
                        },
                        new Food
                        {
                            Name = "Ziemniak",
                            Price = 4.75M,
                            Stock = 430
                        },
                        new Food
                        {
                            Name = "Makaron",
                            Price = 3.65M,
                            Stock = 67
                        },
                        new Food
                        {
                            Name = "Sałata",
                            Price = 7.25M,
                            Stock = 32,
                        }
                    );

                context.SaveChanges();
            }
        }
    }
}
