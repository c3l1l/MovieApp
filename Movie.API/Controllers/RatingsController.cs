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
    public class RatingsController : CustomBaseController
    {
        private readonly IRatingService _service;
        private readonly IMapper _mapper;

        public RatingsController(IRatingService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var ratings = await _service.GetAllAsync();
            var ratingsDto = _mapper.Map<List<RatingDto>>(ratings.ToList());

            return CreateActionResult(CustomResponseDto<List<RatingDto>>.Success(200, ratingsDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rating = await _service.GetByIdAsync(id);
            var ratingDto = _mapper.Map<RatingDto>(rating);
            return CreateActionResult(CustomResponseDto<RatingDto>.Success(200, ratingDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(RatingDto ratingDto)
        {
            var rating = _mapper.Map<Rating>(ratingDto);
            await _service.AddAsync(rating);
            return CreateActionResult(CustomResponseDto<RatingDto>.Success(201, _mapper.Map<RatingDto>(rating)));
        }
        [HttpPut()]
        public async Task<IActionResult> Update(RatingDto ratingDto)
        {
            var rating = _mapper.Map<Rating>(ratingDto);
            await _service.UpdateAsync(rating);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rating = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(rating);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
