using System;
using Microsoft.EntityFrameworkCore;

namespace WebMvc1.Models
{
    public class FilmsContext: DbContext
    {
        public FilmsContext(DbContextOptions<FilmsContext> options) : base(options)
        {
        }

        public DbSet<FilmsModel> FilmsModel { get; set; }
    }
}