using AutoMapper;
using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.GenreOperations.Queries
{
    public class GetGenresQuery
    {
        private readonly ImdbDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenresQuery(ImdbDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GenresVM> Handle()
        {

            var genres = _dbContext.Genres.ToList();
            List<GenresVM> vm = _mapper.Map<List<GenresVM>>(genres);

            return vm;
        }
    }

    public class GenresVM
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public ICollection<MovieNamesVM> Movies { get; set; }
    }
    public class MovieNamesVM
    {
        public string Name { get; set; }
    }

}
