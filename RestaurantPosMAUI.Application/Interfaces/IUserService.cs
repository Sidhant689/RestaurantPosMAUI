using RestaurantPosMAUI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(UserDto createUserDto);
        Task<UserDto> GetUserByIdAsync(int id);
        Task DeleteUserAsync(int id);
        Task<IEnumerable<UserDto>> GetAllUserAsync();
    }
}
