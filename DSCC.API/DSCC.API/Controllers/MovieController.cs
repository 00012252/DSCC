using DSCC.API.Models;
using DSCC.API.MoviesDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DSCC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieContext _movieDbContext;

        public MovieController(MovieContext dbContext)
        {
            _movieDbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAllMovies()
        {
            return new OkObjectResult(_movieDbContext.Movies.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult GetMovie(int id)
        {
            return new OkObjectResult(_movieDbContext.Movies.Find(id));
        }

        [HttpPost]
        public ActionResult PostMovie([FromBody] Movie movie)
        {
            _movieDbContext.Movies.Add(movie);
            _movieDbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult PutMovie([FromBody] Movie movie, int id)
        {
            var oldMovie = _movieDbContext.Movies.Find(id);
            _movieDbContext.Entry(oldMovie).State = EntityState.Modified;
            oldMovie.Title = movie.Title;
            oldMovie.Description = movie.Description;
            oldMovie.Genre = movie.Genre;
            _movieDbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            _movieDbContext.Remove(_movieDbContext.Movies.Find(id));
            _movieDbContext.SaveChanges();
            return Ok();
        }
    }
}
