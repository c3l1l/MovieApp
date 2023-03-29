using AutoMapper;
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
    public class MovieDetailService : Service<MovieDetail>, IMovieDetailService
    {
        private readonly IMovieDetailRepository _movieDetailRepository;
        private readonly IMapper _mapper;
        public MovieDetailService(IGenericRepository<MovieDetail> repository, IUnitOfWork unitOfWork, IMovieDetailRepository movieDetailRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _movieDetailRepository = movieDetailRepository;
            _mapper = mapper;
        }
    }
}
