using AutoMapper;
using MovieApp.Core.DTOs;
using MovieApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Movie,MovieDto>().ReverseMap();
            CreateMap<Genre,GenreDto>().ReverseMap();
            CreateMap<Actor,ActorDto>().ReverseMap();
            CreateMap<Director,DirectorDto>().ReverseMap();
            CreateMap<MovieDetail,MovieDetailDto>().ReverseMap();
            CreateMap<Rating,RatingDto>().ReverseMap();
            CreateMap<UserAppDto,UserApp>().ReverseMap();
        }
    }
}
