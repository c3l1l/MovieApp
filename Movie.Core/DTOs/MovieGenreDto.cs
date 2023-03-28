using MovieApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.DTOs
{
    public class MovieGenreDto:BaseDto
    {

        public string Name { get; set; }

        public int DirectorId { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
