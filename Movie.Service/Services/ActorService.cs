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
    public class ActorService : Service<Actor>, IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        public ActorService(IGenericRepository<Actor> repository, IUnitOfWork unitOfWork, IActorRepository actorRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }
    }
}
