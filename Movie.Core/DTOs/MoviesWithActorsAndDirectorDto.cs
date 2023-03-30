using MovieApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.DTOs
{
    public class MoviesWithActorsAndDirectorDto:BaseDto
    {
        public string Name { get; set; }
        public string DirectorName { get; set; }
        public List<string> Actors { get; set; }

    }
}
