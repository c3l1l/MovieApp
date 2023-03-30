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
    public class GenresController : CustomBaseController
    {
        private readonly IGenreService _service;
        private readonly IMapper _mapper;

        public GenresController(IGenreService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var genres = await _service.GetAllAsync();
            var genresDto = _mapper.Map<List<GenreDto>>(genres.ToList());

            return CreateActionResult(CustomResponseDto<List<GenreDto>>.Success(200, genresDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var genre = await _service.GetByIdAsync(id);
            var genreDto = _mapper.Map<GenreDto>(genre);
            return CreateActionResult(CustomResponseDto<GenreDto>.Success(200, genreDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(GenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            await _service.AddAsync(genre);
            return CreateActionResult(CustomResponseDto<GenreDto>.Success(201, _mapper.Map<GenreDto>(genre)));
        }
        [HttpPut()]
        public async Task<IActionResult> Update(GenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            await _service.UpdateAsync(genre);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var genre = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(genre);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpGet("[Action]/{id}")]
        public async Task<IActionResult> GetGenresWithFilms(int id)
        {
            var genre = await _service.GetGenresWithFilms(id);

            return CreateActionResult(CustomResponseDto<GenresWithMoviesDto>.Success(200, genre));
        }
    }
}
