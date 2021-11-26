using AutoMapper;
using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.MovieOperations.Queries
{
    public class GetMoviesQuery
    {
        private readonly ImdbDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMoviesQuery(ImdbDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MoviesVM> Handle()
        {

            var movies = _dbContext.Movies.ToList();
            List<MoviesVM> vm = _mapper.Map<List<MoviesVM>>(movies);

            return vm;
        }
    }

    public class MoviesVM
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public ICollection<MovieActors> MovieActors { get; set; }
    }
    public class MovieActors
    {
        public string Fullname { get; set; }
    }
}
