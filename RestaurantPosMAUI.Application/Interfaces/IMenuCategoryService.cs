using RestaurantPosMAUI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Application.Interfaces
{
    public interface IMenuCategoryService
    {
        Task<IEnumerable<MenuCategoryDTO>> GetAllMenuCategoryasync();
        Task<MenuCategoryDTO> GetCategoryByIdAsync(int Id);
        Task DeleteCategoryAsync(int Id);
        Task<int> CreateCategoryAsync(MenuCategoryDTO category);
    }
}
