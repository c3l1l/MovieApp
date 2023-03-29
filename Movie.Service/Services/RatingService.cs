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
    public class RatingService : Service<Rating>, IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
        public RatingService(IGenericRepository<Rating> repository, IUnitOfWork unitOfWork, IRatingRepository ratingRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }
    }
}
