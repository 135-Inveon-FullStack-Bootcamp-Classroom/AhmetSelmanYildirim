using Imdb_Clone.Application.DirectorOperations.Commands;
using Imdb_Clone.Application.DirectorOperations.Queries;
using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Imdb_Clone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorController : ControllerBase
    {
        private readonly ImdbDbContext _dbContext;

        public DirectorController(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetDirectors()
        {
            GetDirectorsQuery query = new(_dbContext);
            var directors = query.Handle();

            return Ok(directors);
        }

        [HttpPost]
        public IActionResult AddDirector([FromBody] Director director)
        {
            CreateDirectorCommand command = new(_dbContext);
            command.Handle(director);

            return Ok("Register successfull");
        }

    }
}
