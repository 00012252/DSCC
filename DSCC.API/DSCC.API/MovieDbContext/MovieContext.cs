using Microsoft.EntityFrameworkCore;
using DSCC.API.Models;

namespace DSCC.API.MovieDbContext

{
    // Represents the database context for working with Movie entities
    public class MovieContext : DbContext
    {
        // Constructor that takes DbContextOptions for configuring the context.
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) {
            // Ensure that the database is created when the context is initialized.
            // This method creates the database if it doesn't exist.
            Database.EnsureCreated(); }

        // Represents a DbSet of Movie entities in the database.
        // This DbSet can be used to query and manipulate Movie data.
        public DbSet<Movie> Movies { get; set; }
    }
}
