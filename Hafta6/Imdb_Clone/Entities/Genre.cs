using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imdb_Clone.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies {get;set;}

    }
}
