using AutoMapper;
using MovieApp.Core.DTOs;
using MovieApp.Core.Models;
using MovieApp.Core.Repositories;
using MovieApp.Core.Services;
using MovieApp.Core.UnitOfWorks;
using MovieApp.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Services
{
    public class GenreService : Service<Genre>, IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GenreService(IGenericRepository<Genre> repository, IUnitOfWork unitOfWork, IMapper mapper, IGenreRepository genreRepository) : base(repository, unitOfWork)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<GenresWithMoviesDto> GetGenresWithFilms(int id)
        {
            var genre = await _genreRepository.GetGenresWithFilms(id);
           
                var newGenreDto = new GenresWithMoviesDto();
                newGenreDto.Id = genre.Id;
                newGenreDto.Name = genre.Name;
               
                var newMovieList = new List<Movie>();
                foreach (var movie in genre.Movies)
                {
                    newMovieList.Add(movie.Movie);
                }
                newGenreDto.MovieList = newMovieList;
              
            
            return newGenreDto;
        }
    }
}
