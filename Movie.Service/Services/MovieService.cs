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


        public async Task<List<MovieJoinDto>> GetAllMoviesWithGenre()
        {
            return await _movieRepository.GetAllMoviesWithGenre();
        }
    }
}
