using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var movies=await _service.GetAllAsync();
            var moviesDto = _mapper.Map<List<MovieDto>>(movies.ToList());

            return CreateActionResult(CustomResponseDto<List<MovieDto>>.Success(200,moviesDto));
        }
    }
}
