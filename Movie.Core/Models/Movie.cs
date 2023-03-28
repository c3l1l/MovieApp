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
        //public ICollection<Genre>? Genres { get; set; }
        public MovieGenre? Genre { get; set; }
        // public ICollection<Actor>? Actors { get; set; }
        public MovieActor? Actor { get; set; }
        public MovieDetail? MovieDetail { get; set; }


    }
}
