using MovieApp.Core.DTOs;
using MovieApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Services
{
    public interface IMovieDetailService:IService<MovieDetail>
    {
        Task<MovieDetailDto> GetByMovieIdAsync(int movieId);
        Task<MovieDetail> FileSaveToServer(MovieDetailDto movieDetailDto);

        Task FileDeleteToServer(string path);
    }
}
