using Microsoft.EntityFrameworkCore;
using DSCC.API.Models;

namespace DSCC.API.MovieDbContext

{
    // Represents the database context for working with Movie entities
    public class MovieContext : DbContext
    {
        // Constructor that takes DbContextOptions for configuring the context.
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) 
        {
        }

        // Represents a DbSet of Movie entities in the database.
        // This DbSet can be used to query and manipulate Movie data.
        public DbSet<Movie> Movies { get; set; }
    }
}
