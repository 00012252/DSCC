using Microsoft.EntityFrameworkCore;
using DSCC.API.Models;

namespace DSCC.API.MovieDbContext

{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { Database.EnsureCreated(); }
        public DbSet<Movie> Movies { get; set; }
    }
}
