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
    public class DirectorRepository : GenericRepository<Director>, IDirectorRepository
    {
        public DirectorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
