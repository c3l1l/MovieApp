using AutoMapper;
using MovieApp.Core.DTOs;
using MovieApp.Core.Models;
using MovieApp.Core.Repositories;
using MovieApp.Core.Services;
using MovieApp.Core.UnitOfWorks;
using MovieApp.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Services
{
    public class MovieDetailService : Service<MovieDetail>, IMovieDetailService
    {
        private readonly IMovieDetailRepository _movieDetailRepository;
        private readonly IMapper _mapper;
        public MovieDetailService(IGenericRepository<MovieDetail> repository, IUnitOfWork unitOfWork, IMovieDetailRepository movieDetailRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _movieDetailRepository = movieDetailRepository;
            _mapper = mapper;
        }

        public async Task<MovieDetailDto> GetByMovieIdAsync(int movieId)
        {
            var hasProduct = await _movieDetailRepository.GetByMovieIdAsync(movieId);
            if (hasProduct == null)
            {
                throw new NotFoundException($"Movie with ({movieId}) id number {typeof(MovieDetail).Name} not found");
            }
           
        //var movieDetail=await _movieDetailRepository.GetByMovieIdAsync(movieId);
            var movieDetailDto = _mapper.Map<MovieDetailDto>(hasProduct);
            return movieDetailDto;
        }
    }
}
