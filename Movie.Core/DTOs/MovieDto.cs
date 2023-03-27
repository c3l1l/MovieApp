using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.DTOs
{
    public class MovieDto:BaseDto
    {
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
    }
}
