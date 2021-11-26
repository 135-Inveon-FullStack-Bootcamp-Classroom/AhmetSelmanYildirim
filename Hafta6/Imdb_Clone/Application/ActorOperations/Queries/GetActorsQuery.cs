using AutoMapper;
using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.ActorOperations.Queries
{
    public class GetActorsQuery
    {
        private readonly ImdbDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActorsQuery(ImdbDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ActorsVM> Handle()
        {

            var actors = _dbContext.Actors.ToList();

            List<ActorsVM> vm = _mapper.Map<List<ActorsVM>>(actors);

            return vm;
        }
    }

    public class ActorsVM
    {
        public int ActorId { get; set; }
        public string Fullname { get; set; }
        public ICollection<ActorMoviesDTO> MovieActors { get; set; }

    }
    public class ActorMoviesDTO
    {
        public string Name { get; set; }
    }
}
