using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.MovieOperations.Commands
{
    public class UpdateMovieCommand
    {
        private readonly ImdbDbContext _dbContext;
        public UpdateMovieVM Model { get; set; }
        public int MovieId { get; set; }

        public UpdateMovieCommand(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {

            var movie = _dbContext.Movies.SingleOrDefault(x => x.MovieId == MovieId);

            if(movie is null)
            {
                throw new InvalidOperationException("Movie not found");
            }

            movie.Name = Model.Name;
            movie.GenreId = Model.GenreId;
            movie.DirectorId = Model.DirectorId;
            movie.Actors = Model.Actors;
            movie.Year = Model.Year;

            _dbContext.SaveChanges();

        }

        public class UpdateMovieVM
        {
            public string Name { get; set; }
            public string Year { get; set; }
            public int GenreId { get; set; }
            public int DirectorId { get; set; }
            public string Actors { get; set; }
        }

    }
}
