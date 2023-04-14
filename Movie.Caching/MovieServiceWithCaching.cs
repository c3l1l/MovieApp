using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MovieApp.Core.DTOs;
using MovieApp.Core.Models;
using MovieApp.Core.Repositories;
using MovieApp.Core.Services;
using MovieApp.Core.UnitOfWorks;
using MovieApp.Repository.Repositories;
using MovieApp.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Caching
{
    public class MovieServiceWithCaching : IMovieService
    {
        private const string CacheMovieKey = "moviesCache";
        private readonly IMapper _mapper;
        private readonly IMovieRepository _repository;
        private readonly IMemoryCache _memoryCache;
        private readonly IUnitOfWork _unitOfWork;

        public MovieServiceWithCaching(IMapper mapper, IMovieRepository repository, IMemoryCache memoryCache, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _memoryCache = memoryCache;
            _unitOfWork = unitOfWork;
            if (!_memoryCache.TryGetValue(CacheMovieKey,out _))
            {
                _memoryCache.Set(CacheMovieKey, _repository.GetMoviesWithActorsAndDirector().Result);
            }
        }

        public async Task<Movie> AddAsync(Movie entity)
        {
          await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllMoviesAsync();
            return entity;
        }

        public async Task<IEnumerable<Movie>> AddRangeAsync(IEnumerable<Movie> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllMoviesAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Movie, bool>> expression)
        {
            var movie= _memoryCache.Get<List<Movie>>(CacheMovieKey).Any(expression.Compile());
            return Task.FromResult(movie);
        }

        public Task<IEnumerable<Movie>> GetAllAsync()
        {
           return Task.FromResult(_memoryCache.Get<IEnumerable<Movie>>(CacheMovieKey));
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            var movie= _memoryCache.Get<List<Movie>>(CacheMovieKey).FirstOrDefault(x=>x.Id==id);
            if (movie==null)
            {
                throw new NotFoundException($"{typeof(Movie).Name} ({id}) not found");
            }
            return Task.FromResult(movie);
        }

        public Task<List<MoviesWithActorsAndDirectorDto>> GetMoviesWithActorsAndDirector()
        {
            //var movies = _memoryCache.Get<IEnumerable<Movie>>(CacheMovieKey);
            //var moviesWithCateforyDto = _mapper.Map<List<MoviesWithActorsAndDirectorDto>>(movies);
            //return Task.FromResult(moviesWithCateforyDto);
            var movies = _memoryCache.Get<IEnumerable<Movie>>(CacheMovieKey);
            var moviesDto = new List<MoviesWithActorsAndDirectorDto>();


            foreach (var movie in movies)
            {
                var newMovieDto = new MoviesWithActorsAndDirectorDto();
                newMovieDto.Id = movie.Id;
                newMovieDto.Name = movie.Name;
                newMovieDto.DirectorName = $"{movie.Director.FirstName} {movie.Director.LastName}";
                var newActorList = new List<string>();
                foreach (var actor in movie.Actors)
                {
                    newActorList.Add($"{actor.Actor.FirstName} {actor.Actor.Lastname}");
                }
                newMovieDto.Actors = newActorList;
                moviesDto.Add(newMovieDto);
            }
            return Task.FromResult(moviesDto);
        }

        public async Task RemoveAsync(Movie entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllMoviesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Movie> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllMoviesAsync();
        }

        public async Task UpdateAsync(Movie entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllMoviesAsync();
        }

        public IQueryable<Movie> Where(Expression<Func<Movie, bool>> expression)
        {
           return _memoryCache.Get<List<Movie>>(CacheMovieKey).Where(expression.Compile()).AsQueryable();
        }
        public async Task CacheAllMoviesAsync()
        {
            _memoryCache.Set(CacheMovieKey, await _repository.GetAll().ToListAsync());
        }
    }
}
