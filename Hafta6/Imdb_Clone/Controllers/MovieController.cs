using AutoMapper;
using Imdb_Clone.Application.MovieOperations.Commands;
using Imdb_Clone.Application.MovieOperations.Queries;
using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using Microsoft.AspNetCore.Mvc;
using static Imdb_Clone.Application.MovieOperations.Commands.UpdateMovieCommand;

namespace Imdb_Clone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ImdbDbContext _dbContext;
        private readonly IMapper _mapper;

        public MovieController(ImdbDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMoviesQuery query = new(_dbContext, _mapper);
            var movies = query.Handle();

            return Ok(movies);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieVM movie)
        {
            CreateMovieCommand command = new(_dbContext, _mapper);
            command.Model = movie;
            command.Handle();

            return Ok("Register successfull");
        }

        [HttpPut("id")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieVM updatedMovie)
        {
            UpdateMovieCommand command = new(_dbContext);
            command.MovieId = id;
            command.Model = updatedMovie;
            command.Handle();

            return Ok("Update successfull");
        }

        [HttpDelete("id")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command = new(_dbContext);
            command.MovieId = id;
            command.Handle();

            return Ok("Delete successfull");
        }

    }
}
