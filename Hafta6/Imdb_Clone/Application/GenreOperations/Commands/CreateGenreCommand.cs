using AutoMapper;
using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.GenreOperations.Commands
{
    public class CreateGenreCommand
    {
        private readonly ImdbDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateGenreVM Model;

        public CreateGenreCommand(ImdbDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Name == Model.Name);

            if (genre is not null)
            {
                throw new InvalidOperationException("Genre already exist");
            }

            genre = _mapper.Map<Genre>(Model);

            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();

        }
    }

    public class CreateGenreVM
    {
        public string Name { get; set; }
    }
}
