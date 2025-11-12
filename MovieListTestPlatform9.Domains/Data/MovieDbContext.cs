using Microsoft.EntityFrameworkCore;
using MovieListTestPlatform9.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieListTestPlatform9.Domains.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
