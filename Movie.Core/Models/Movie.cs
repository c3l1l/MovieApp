using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Models
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }

        public int DirectorId { get; set; }
        public Director? Director { get; set; }
        public virtual ICollection<MovieGenre>? Genres { get; set; }
        public virtual ICollection<MovieActor>? Actors { get; set; }
        public MovieDetail? MovieDetail { get; set; }

    }
}
