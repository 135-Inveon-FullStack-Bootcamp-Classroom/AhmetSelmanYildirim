using AutoMapper;
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
        private readonly IMapper _mapper;

        public ActorController(ImdbDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            GetActorsQuery query = new(_dbContext, _mapper);
            var actors = query.Handle();

            return Ok(actors);
        }

        [HttpPost]
        public IActionResult AddActor([FromBody] CreateActorVM actor)
        {
            CreateActorCommand command = new(_dbContext, _mapper);
            command.Model = actor;
            command.Handle();

            return Ok("Register successfull");
        }

        [HttpPut("id")]
        public IActionResult UpdateActor(int id, [FromBody] UpdateActorVM updatedActor)
        {
            UpdateActorCommand command = new(_dbContext);
            command.ActorId = id;
            command.Model = updatedActor;
            command.Handle();

            return Ok("Update successfull");
        }

        [HttpDelete("id")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command = new(_dbContext);
            command.ActorId = id;
            command.Handle();

            return Ok("Delete successfull");
        }

    }
}
