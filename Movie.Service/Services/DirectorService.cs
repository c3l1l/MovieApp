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
    public class DirectorService : Service<Director>, IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;
        public DirectorService(IGenericRepository<Director> repository, IUnitOfWork unitOfWork, IDirectorRepository directorRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _directorRepository = directorRepository;
            _mapper = mapper;
        }
    }
}
