using Microsoft.EntityFrameworkCore;
using MovieApp.Core.DTOs;
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
    public class MovieRepository:GenericRepository<Movie>, IMovieRepository
    {
        
        public MovieRepository(AppDbContext context):base(context)
        {

        }

        public async Task<List<Movie>> GetMoviesWithActorsAndDirector()
        {
            var movies=await _context.Movies.Include(x=>x.Actors).ThenInclude(y=>y.Actor).Include(x => x.Director).ToListAsync();
            return movies;

        }
    }
}
