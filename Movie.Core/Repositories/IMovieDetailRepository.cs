using MovieApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Repositories
{
    public interface IMovieDetailRepository:IGenericRepository<MovieDetail>
    {
        Task<MovieDetail> GetByMovieIdAsync(int movieId);
    }
}
