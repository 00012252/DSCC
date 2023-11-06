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
            return new OkObjectResult(_context.Movies.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult GetMovie(int id)
        {
            return new OkObjectResult(_context.Movies.Find(id));
        }

        [HttpPost]
        public ActionResult PostMovie([FromBody] Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult PutMovie([FromBody] Movie movie, int id)
        {
            var oldMovie = _context.Movies.Find(id);
            _context.Entry(oldMovie).State = EntityState.Modified;
            oldMovie.Title = movie.Title;
            oldMovie.Description = movie.Description;
            oldMovie.Genre = movie.Genre;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            _context.Remove(_context.Movies.Find(id));
            _context.SaveChanges();
            return Ok();
        }
    }
}
