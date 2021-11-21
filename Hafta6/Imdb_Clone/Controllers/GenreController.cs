using Imdb_Clone.Application.GenreOperations.Commands;
using Imdb_Clone.Application.GenreOperations.Queries;
using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly ImdbDbContext _dbContext;

        public GenreController(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new(_dbContext);
            var genres = query.Handle();

            return Ok(genres);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] Genre genre)
        {
            CreateGenreCommand command = new(_dbContext);
            command.Handle(genre);

            return Ok("Register successfull");
        }

    }
}
