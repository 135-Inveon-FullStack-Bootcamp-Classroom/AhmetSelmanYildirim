using Imdb_Clone.Application.ActorOperations.Commands;
using Imdb_Clone.Application.ActorOperations.Queries;
using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Imdb_Clone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly ImdbDbContext _dbContext;

        public ActorController(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            GetActorsQuery query = new(_dbContext);
            var actors = query.Handle();

            return Ok(actors);
        }

        [HttpPost]
        public IActionResult AddActor([FromBody] Actor actor)
        {
            CreateActorCommand command = new(_dbContext);
            command.Handle(actor);

            return Ok("Register successfull");
        }

    }
}
