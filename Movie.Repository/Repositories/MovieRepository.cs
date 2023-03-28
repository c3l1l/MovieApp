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
        public async Task<List<MovieJoinDto>> GetAllMoviesWithGenre()
        {
            // return _context.Movies.Include(x=>x.Genre).ToList();
            var result = from m in _context.Movies
                         join g in _context.MovieGenre
                         on m.Id equals g.MovieId
                         select new MovieJoinDto
                         {
                             Id = m.Id,
                             Name = m.Name,
                             DirectorId = m.DirectorId,
                             Genre = g.GenreId
                         };
            return  result.ToList();
        }

    }
}
