using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MovieApp.Core.DTOs;
using MovieApp.Core.Models;
using MovieApp.Core.Repositories;
using MovieApp.Core.Services;
using MovieApp.Core.UnitOfWorks;
using MovieApp.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Services
{
    public class MovieDetailService : Service<MovieDetail>, IMovieDetailService
    {
        private readonly IMovieDetailRepository _movieDetailRepository;
        private readonly IMapper _mapper;
        private readonly IHostEnvironment _env;

        public MovieDetailService(IGenericRepository<MovieDetail> repository, IUnitOfWork unitOfWork, IMovieDetailRepository movieDetailRepository, IMapper mapper, IHostEnvironment env) : base(repository, unitOfWork)
        {
            _movieDetailRepository = movieDetailRepository;
            _mapper = mapper;
            _env = env;
        }

        public async Task<MovieDetailDto> GetByMovieIdAsync(int movieId)
        {
            var hasProduct = await _movieDetailRepository.GetByMovieIdAsync(movieId);
            if (hasProduct == null)
            {
                throw new NotFoundException($"Movie with ({movieId}) id number {typeof(MovieDetail).Name} not found");
            }
           
        //var movieDetail=await _movieDetailRepository.GetByMovieIdAsync(movieId);
            var movieDetailDto = _mapper.Map<MovieDetailDto>(hasProduct);
            return movieDetailDto;
        }

        //[NonAction]
        //public MovieDetail GetMovieFromMovieDto(MovieDetailDto movieDetailDto)
        //{

        //    MovieDetail movieDetail = _mapper.Map<MovieDetail>(movieDetailDto);
        //    string strRootPath = _env.ContentRootPath;
        //    Guid guid = Guid.NewGuid();
        //    string strNewImageName = guid.ToString() + movieDetailDto.Poster.FileName;
        //    string strImagePath = Path.Combine(strRootPath + "Content/images/" + strNewImageName);

        //    using (FileStream fs = new FileStream(strImagePath, FileMode.Create))
        //    {
        //        movieDetail.Poster.CopyToAsync(fs);
        //        fs.Close();
        //        movieDetail.PosterPath = strNewImageName;
        //    }
        //    return movieDetail;
        //}

      
        /// <summary>
        /// This method gets MovieDetailDto model and maps to MovieDetail model.
        /// Sending image file renames and saves under content/images folder with new name.
        /// 
        /// </summary>
        /// <param name="movieDetailDto"></param>
        /// <returns></returns>
        async Task<MovieDetail> IMovieDetailService.GetMovieFromMovieDto(MovieDetailDto movieDetailDto)
        {
            MovieDetail movieDetail = _mapper.Map<MovieDetail>(movieDetailDto);
            string strRootPath = _env.ContentRootPath;
            Guid guid = Guid.NewGuid();
            string strNewImageName = guid.ToString() + movieDetailDto.Poster.FileName;
            string strImagePath = Path.Combine(strRootPath + "wwwroot/images/" + strNewImageName);

            using (FileStream fs = new FileStream(strImagePath, FileMode.Create))
            {
                movieDetail.Poster.CopyToAsync(fs);
                fs.Close();
                movieDetail.PosterPath = strNewImageName;
            }
            return movieDetail;
        }
    }
}
