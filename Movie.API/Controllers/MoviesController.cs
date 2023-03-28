using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.Filters;
using MovieApp.Core.DTOs;
using MovieApp.Core.Models;
using MovieApp.Core.Services;

namespace MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IMovieService _service;

        public MoviesController(IMapper mapper, IMovieService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var movies = await _service.GetAllAsync();
            var moviesDto = _mapper.Map<List<MovieDto>>(movies.ToList());

            return CreateActionResult(CustomResponseDto<List<MovieDto>>.Success(200, moviesDto));
        }
        //[HttpGet]
        //public async Task<IActionResult> AllWithGenre()
        //{
        //    var movies = await _service.GetAllMoviesWithGenre();
        //    var moviesDto = _mapper.Map<List<MovieDto>>(movies.ToList());

        //    return CreateActionResult(CustomResponseDto<List<MovieDto>>.Success(200, moviesDto));
        //}

        //[ServiceFilter(typeof(NotFoundFilter<MovieApp.Core.Models.Movie>))]   //Buradaki tipide program.cs icinde servis olarak eklenmelidir.builder.Services.AddScoped(typeof(NotFoundFilter<>)); 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie=await _service.GetByIdAsync(id);
            var movieDto = _mapper.Map<MovieDto>(movie);
            return CreateActionResult(CustomResponseDto<MovieDto>.Success(200, movieDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(MovieDto movieDto)
        {
            var movie = _mapper.Map<MovieApp.Core.Models.Movie>(movieDto);
            await _service.AddAsync(movie);
            return CreateActionResult(CustomResponseDto<MovieDto>.Success(201, _mapper.Map<MovieDto>(movie)));
        }
        [HttpPut()]
        public async Task<IActionResult> Update(MovieDto movieDto)
        {
             var movie = _mapper.Map<MovieApp.Core.Models.Movie>(movieDto);
             await _service.UpdateAsync(movie);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(movie);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
