using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieApp.Core.DTOs
{
    public class MovieDetailDto:BaseDto
    {
        public DateTime? DateReleased { get; set; }
        public double Rating { get; set; }
       
        public IFormFile? Poster { get; set; }

        //[JsonIgnore]
        public string? PosterPath { get; set; }
        public int MovieId { get; set; }
    }
}
