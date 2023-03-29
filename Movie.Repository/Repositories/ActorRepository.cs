using MovieApp.Core.Models;
using MovieApp.Core.Repositories;
using MovieApp.Repository.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repository.Repositories
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
