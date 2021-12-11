using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebMvc1.Data;

namespace WebMvc1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebMvc1Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebMvc1Context>>()))
            {
                // Look for any movies.
                if (context.CarModel.Any())
                {
                    return;   // DB has been seeded
                }
                context.CarModel.AddRange(
                    new CarModel
                    {
                        Brand = "Audi",
                        Model = "S3",
                        Type = "Sedan",
                        Millage = 13548M,
                        ManufactureDate = DateTime.Parse("2018-2-12")
                    },
                    new CarModel
                    {

                        Brand = "BMW",
                        Model = "M3",
                        Type = "Sedan",
                        Millage = 24958.56M,
                        ManufactureDate = DateTime.Parse("2016-11-23")
                    },
                    new CarModel
                    {
                        Brand = "Volkswagen",
                        Model = "Golf",
                        Type = "Hatchback",
                        Millage = 0M,
                        ManufactureDate = DateTime.Parse("2021-11-25")
                    },
                    new CarModel
                    {
                        Brand = "Skoda",
                        Model = "Superb",
                        Type = "Wagon",
                        Millage = 122065.85M,
                        ManufactureDate = DateTime.Parse("2015-8-23")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
