using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.API.Filters;
using MovieApp.Core.DTOs;
using MovieApp.Core.Models;
using MovieApp.Core.Services;

namespace MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDetailsController : CustomBaseController
    {
        private readonly IMovieDetailService _service;
        private readonly IMapper _mapper;

        public MovieDetailsController(IMovieDetailService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var movieDetails = await _service.GetAllAsync();
            var movieDetailsDto = _mapper.Map<List<MovieDetailDto>>(movieDetails.ToList());

            return CreateActionResult(CustomResponseDto<List<MovieDetailDto>>.Success(200, movieDetailsDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movieDetail = await _service.GetByIdAsync(id);
            movieDetail.PosterPath = CreateImageUrl(movieDetail.PosterPath);
            var movieDetailDto = _mapper.Map<MovieDetailDto>(movieDetail);
            return CreateActionResult(CustomResponseDto<MovieDetailDto>.Success(200, movieDetailDto));
        }
        [HttpGet("[Action]/{id}")]
       // [ServiceFilter(typeof(NotFoundFilter<Movie>))]
        public async Task<IActionResult> GetByMovieId(int id)
        {
            var movieDetailDto = await _service.GetByMovieIdAsync(id);
            movieDetailDto.PosterPath = CreateImageUrl(movieDetailDto.PosterPath);

            return CreateActionResult(CustomResponseDto<MovieDetailDto>.Success(200, movieDetailDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromForm]MovieDetailDto movieDetailDto)
        {
            //var movieDetail = _mapper.Map<MovieDetail>(movieDetailDto);
            var movieDetail=await _service.FileSaveToServer(movieDetailDto);
            await _service.AddAsync(movieDetail);
            return CreateActionResult(CustomResponseDto<MovieDetailDto>.Success(201, _mapper.Map<MovieDetailDto>(movieDetail)));
        }
        [HttpPut()]
        public async Task<IActionResult> Update([FromForm] MovieDetailDto movieDetailDto)
        {
            //  var movieDetail = _mapper.Map<MovieDetail>(movieDetailDto);
            string[] words = movieDetailDto.PosterPath.Split('/');
            var oldImagePath = "wwwroot/images/" + words[4];
            await _service.FileDeleteToServer(oldImagePath);
            var movieDetail = await _service.FileSaveToServer(movieDetailDto);
            await _service.UpdateAsync(movieDetail);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movieDetail = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(movieDetail);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        /// <summary>
        /// This method creates image Url using to the ImagePath property in MovieDetail model.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [NonAction]
        public string CreateImageUrl(string filePath)
        {
            var baseUri = $"{Request.Scheme}://{Request.Host}/";
            string imageurl = $"{baseUri}images/{filePath}";
            return imageurl;
        }

    }
}
