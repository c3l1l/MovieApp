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
    public class ActorsController : CustomBaseController
    {
        private readonly IActorService _service;
        private readonly IMapper _mapper;

        public ActorsController(IActorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var actors = await _service.GetAllAsync();
            var actorsDto = _mapper.Map<List<ActorDto>>(actors.ToList());

            return CreateActionResult(CustomResponseDto<List<ActorDto>>.Success(200, actorsDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var actor = await _service.GetByIdAsync(id);
            var actorDto = _mapper.Map<ActorDto>(actor);
            return CreateActionResult(CustomResponseDto<ActorDto>.Success(200, actorDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ActorDto actorDto)
        {
            var actor = _mapper.Map<Actor>(actorDto);
            await _service.AddAsync(actor);
            return CreateActionResult(CustomResponseDto<ActorDto>.Success(201, _mapper.Map<ActorDto>(actor)));
        }
        [HttpPut()]
        public async Task<IActionResult> Update(ActorDto actorDto)
        {
            var actor = _mapper.Map<Actor>(actorDto);
            await _service.UpdateAsync(actor);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(actor);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
