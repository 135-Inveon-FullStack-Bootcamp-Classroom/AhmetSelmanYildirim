using AutoMapper;
using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.ActorOperations.Commands
{
    public class CreateActorCommand
    {
        private readonly ImdbDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateActorVM Model;

        public CreateActorCommand(ImdbDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(x => x.Name == Model.Name);

            if (actor is not null)
            {
                throw new InvalidOperationException("Actor already exist");
            }

            actor = _mapper.Map<Actor>(Model);

            _dbContext.Actors.Add(actor);
            _dbContext.SaveChanges();

        }
    }
    public class CreateActorVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
