using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Models
{
    public class MovieDetail:BaseEntity
    {
        public DateTime? DateReleased { get; set; }
        public double Rating { get; set; }
        public string PosterPath { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }

    }
}
