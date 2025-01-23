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
    }
}
