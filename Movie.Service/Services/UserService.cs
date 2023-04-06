using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Identity;
using MovieApp.Core.DTOs;
using MovieApp.Core.Models;
using MovieApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<UserApp> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user=new UserApp { Email= createUserDto.Email, UserName=createUserDto.UserName };

            var result=await _userManager.CreateAsync(user,createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return CustomResponseDto<UserAppDto>.Fail(400, errors);

            }
            return CustomResponseDto<UserAppDto>.Success(200, _mapper.Map<UserAppDto>(user));
        }

        public Task<CustomResponseDto<NoContentDto>> CreateUserRoles(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomResponseDto<UserAppDto>> GetUserByNameAsync(string userName)
        {
            var user=await _userManager.FindByIdAsync(userName);
            if (user==null)
            {
                return CustomResponseDto<UserAppDto>.Fail(404, "User Name not found");
            }
            return CustomResponseDto<UserAppDto>.Success(200, _mapper.Map<UserAppDto>(user));

        }
    }
}
