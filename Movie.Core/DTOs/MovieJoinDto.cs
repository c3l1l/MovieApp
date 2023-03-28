using MovieApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.DTOs
{
    public class MovieJoinDto:BaseDto
    {
        public string Name { get; set; }

        public int DirectorId { get; set; }
        public int Genre { get; set; }

    }
}
