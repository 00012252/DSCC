using DSCC.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DSCC.API.MoviesDbContext
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { Database.EnsureCreated(); }

        public DbSet<Movie> Movies { get; set; }
    }
}
