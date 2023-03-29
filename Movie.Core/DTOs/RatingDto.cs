using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.DTOs
{
    public class RatingDto:BaseDto
    {
        public double ReviewStars { get; set; }
        public int MovieId { get; set; }
    }
}
