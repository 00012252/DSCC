using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DSCC.API.Models;
using DSCC.API.MovieDbContext;

namespace DSCC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAllMovies()
        {
            // Return a list of all movies in the database.
            return new OkObjectResult(_context.Movies.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult GetMovie(int id)
        {
            // Find and return a specific movie by its ID.
            return new OkObjectResult(_context.Movies.Find(id));
        }

        [HttpPost]
        public ActionResult PostMovie([FromBody] Movie movie)
        {
            // Add a new movie to the database and save changes.
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult PutMovie([FromBody] Movie movie, int id)
        {
            // Find the old movie by its ID.
            var oldMovie = _context.Movies.Find(id);

            // Set the state of the old movie to Modified for updating.
            _context.Entry(oldMovie).State = EntityState.Modified;

            // Update the properties of the old movie with the new movie's data.
            oldMovie.Title = movie.Title;
            oldMovie.Description = movie.Description;
            oldMovie.Genre = movie.Genre;

            // Save changes to apply the update.
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            // Find and remove a specific movie by its ID from the database.
            _context.Remove(_context.Movies.Find(id));

            // Save changes to apply the deletion.
            _context.SaveChanges();
            return Ok();
        }
    }
}
