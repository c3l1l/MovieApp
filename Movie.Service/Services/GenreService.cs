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
    public class GenreService : Service<Genre>, IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GenreService(IGenericRepository<Genre> repository, IUnitOfWork unitOfWork, IMapper mapper, IGenreRepository genreRepository) : base(repository, unitOfWork)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

    }
}
