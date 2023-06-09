﻿using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Models;
using MovieApp.Core.Repositories;
using MovieApp.Repository.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repository.Repositories
{
    public class MovieDetailRepository : GenericRepository<MovieDetail>, IMovieDetailRepository
    {
        public MovieDetailRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<MovieDetail> GetByMovieIdAsync(int movieId)
        {
         var movieDetail=  await _context.MoviesDetails.Where(x=>x.MovieId==movieId).FirstOrDefaultAsync();
            return movieDetail;
        }
    }
}
