using Imdb_Clone.Application.MovieOperations.Commands;
using Imdb_Clone.Application.MovieOperations.Queries;
using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Imdb_Clone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ImdbDbContext _dbContext;

        public MovieController(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMoviesQuery query = new(_dbContext);
            var movies = query.Handle();

            return Ok(movies);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            CreateMovieCommand command = new(_dbContext);
            command.Handle(movie);

            return Ok("Register successfull");
        }

    }
}
