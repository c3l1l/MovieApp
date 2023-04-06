using MovieApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Services
{
    public interface IUserService
    {
        Task<CustomResponseDto<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<CustomResponseDto<UserAppDto>> GetUserByNameAsync(string userName);

        Task<CustomResponseDto<NoContentDto>> CreateUserRoles(string userName);
    }
}
