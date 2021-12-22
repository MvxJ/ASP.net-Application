using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMvc1.Models;

namespace WebMvc1.Data
{
    public class WebMvc1Context : DbContext
    {
        public WebMvc1Context (DbContextOptions<WebMvc1Context> options)
            : base(options)
        {
        }

        public DbSet<WebMvc1.Models.CarModel> CarModel { get; set; }

        public DbSet<WebMvc1.Models.FilmsModel> FilmsModel { get; set; }
    }
}
