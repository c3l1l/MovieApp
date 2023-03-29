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
        public virtual Movie Movie { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
