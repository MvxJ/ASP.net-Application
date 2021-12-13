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
            using (var context = new FilmsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FilmsContext>>()))
            {
                if (context.FilmsModel.Any())
                {
                    return;
                }

                context.FilmsModel.AddRange(
                    new FilmsModel
                    {
                        Title = "FREE GUY",
                        Description = "Fantastycznonaukowa komedia akcji z 2021 roku w reżyserii Shawna Levy'ego. Jej scenariusz, napisali Matt Lieberman i Zak Penn",
                        Type = "Comedy",
                        Rating = 9.56M,
                        ReleaseDate = DateTime.Parse("2021-8-13")
                    },
                    new FilmsModel
                    {
                        Title = "SZYBCY I WŚCIEKLI 9",
                        Description = "Amerykański film akcji w reżyserii Justina Lina z 2021 roku. Scenariusz do filmu napisali Chris Morgan oraz Daniel Casey.",
                        Type = "Action",
                        Rating = 9.56M,
                        ReleaseDate = DateTime.Parse("2021-6-25")
                    },
                    new FilmsModel
                    {
                        Title = "OBECNOŚĆ 3: NA ROZKAZ DIABŁA",
                        Description = "Amerykański horror z 2021 roku w reżyserii Michaela Chavesa. Jego scenariusz napisał David Leslie Johnson-McGoldrick.",
                        Type = "Horror",
                        Rating = 9.56M,
                        ReleaseDate = DateTime.Parse("2021-6-04")
                    },
                    new FilmsModel
                    {
                        Title = "BAD TRIP",
                        Description = "Bad Trip to amerykański film komediowy z 2021 r. w reżyserii Kitao Sakurai. Film opowiada o dwójce najlepszych przyjaciół, którzy wybierają się w podróż z Florydy do Nowego Jorku.",
                        Type = "Comedy",
                        Rating = 9.56M,
                        ReleaseDate = DateTime.Parse("2021-3-26")
                    }
                );

                context.SaveChanges();
            }

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
