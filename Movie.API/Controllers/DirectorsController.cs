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
    public class DirectorsController : CustomBaseController
    {
        private readonly IDirectorService _service;
        private readonly IMapper _mapper;

        public DirectorsController(IDirectorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var directors = await _service.GetAllAsync();
            var directorsDto = _mapper.Map<List<DirectorDto>>(directors.ToList());

            return CreateActionResult(CustomResponseDto<List<DirectorDto>>.Success(200, directorsDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var director = await _service.GetByIdAsync(id);
            var directorDto = _mapper.Map<DirectorDto>(director);
            return CreateActionResult(CustomResponseDto<DirectorDto>.Success(200, directorDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(DirectorDto directorDto)
        {
            var director = _mapper.Map<Director>(directorDto);
            await _service.AddAsync(director);
            return CreateActionResult(CustomResponseDto<DirectorDto>.Success(201, _mapper.Map<DirectorDto>(director)));
        }
        [HttpPut()]
        public async Task<IActionResult> Update(DirectorDto directorDto)
        {
            var director = _mapper.Map<Director>(directorDto);
            await _service.UpdateAsync(director);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var director = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(director);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
