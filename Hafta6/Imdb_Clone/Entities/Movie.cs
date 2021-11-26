using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int DirectorId {get;set;}
        public virtual Director Director { get; set; }
        public virtual ICollection<MovieActor> MovieActors { get; set; }
    }
}
