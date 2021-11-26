using AutoMapper;
using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.DirectorOperations.Commands
{
    public class CreateDirectorCommand
    {

        private readonly ImdbDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateDirectorVM Model { get; set; }

        public CreateDirectorCommand(ImdbDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);

            if (director is not null)
            {
                throw new InvalidOperationException("Director already exist");
            }

            director = _mapper.Map<Director>(Model);

            _dbContext.Directors.Add(director);
            _dbContext.SaveChanges();

        }

    }

    public class CreateDirectorVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
