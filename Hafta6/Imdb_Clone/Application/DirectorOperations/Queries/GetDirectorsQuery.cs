using AutoMapper;
using Imdb_Clone.Application.GenreOperations.Queries;
using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.DirectorOperations.Queries
{
    public class GetDirectorsQuery
    {
        private readonly ImdbDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorsQuery(ImdbDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<DirectorsVM> Handle()
        {

            var directors = _dbContext.Directors.ToList();
            List<DirectorsVM> vm = _mapper.Map<List<DirectorsVM>>(directors);

            return vm;
        }
    }

    public class DirectorsVM
    {
        public int DirectorId { get; set; }
        public string Fullname { get; set; }
        public ICollection<MovieNamesDTO> Movies { get; set; }

    }
}
