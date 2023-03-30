using AutoMapper;
using MovieApp.Core.DTOs;
using MovieApp.Core.Models;
using MovieApp.Core.Repositories;
using MovieApp.Core.Services;
using MovieApp.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Services
{
    public class MovieService : Service<Movie>, IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IGenericRepository<Movie> repository, IUnitOfWork unitOfWork, IMovieRepository movieRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<MoviesWithActorsAndDirectorDto>> GetMoviesWithActorsAndDirector()
        {
            var movies=await _movieRepository.GetMoviesWithActorsAndDirector();
            var moviesDto=new List<MoviesWithActorsAndDirectorDto>();

            foreach (var movie in movies)
            {
                var newMovieDto = new MoviesWithActorsAndDirectorDto();
                newMovieDto.Id = movie.Id;
                 newMovieDto.Name = movie.Name;
                newMovieDto.DirectorName= $"{movie.Director.FirstName} {movie.Director.LastName}";
                var newActorList = new List<string>();
                foreach (var actor in movie.Actors)
                {
                    newActorList.Add($"{ actor.Actor.FirstName} {actor.Actor.Lastname}");
                }
                newMovieDto.Actors = newActorList;
                moviesDto.Add(newMovieDto);
            }
            return moviesDto;
        }
    }
}
