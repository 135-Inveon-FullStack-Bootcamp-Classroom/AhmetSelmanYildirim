using AutoMapper;
using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.MovieOperations.Commands
{
    public class CreateMovieCommand
    {
        private readonly ImdbDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateMovieVM Model { get; set; }

        public CreateMovieCommand(ImdbDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Name == Model.Name);

            if (movie is not null)
            {
                throw new InvalidOperationException("Movie already exist");
            }

            movie = _mapper.Map<Movie>(Model);

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

        }
    }

    public class CreateMovieVM
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }

    }
}
