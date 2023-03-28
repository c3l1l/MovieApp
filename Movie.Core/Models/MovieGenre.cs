using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Models
{
    public class MovieGenre:BaseEntity
    {
        public int GenreId { get; set; }
        public int MovieId { get; set; }

        public ICollection<Movie> Movies { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
