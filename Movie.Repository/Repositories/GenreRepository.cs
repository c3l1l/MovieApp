using Microsoft.EntityFrameworkCore;
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
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Genre> GetGenresWithFilms(int id)
        {

            var genre = await _context.Genres.Include(x => x.Movies).ThenInclude(y => y.Movie).Where(g => g.Id == id).Select(x => new Genre()
            {
                Id = x.Id,
                Name = x.Name,
                Movies = x.Movies
            }).FirstOrDefaultAsync();

            //var genre = (from gm in _context.MovieGenre
            //             join g in _context.Genres on gm.GenreId equals g.Id
            //             join m in _context.Movies on gm.MovieId equals m.Id
            //             where gm.GenreId == id
            //             select new
            //             {
            //                 Id = gm.Id,
            //                 GenreName = g.Name,
            //                 MovieName = m,
            //             });
            return genre;
        }
    }
}
