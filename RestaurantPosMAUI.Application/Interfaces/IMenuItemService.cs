using RestaurantPosMAUI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Application.Interfaces
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItemDTO>> GetAllMenuItemsAsync();
        Task<MenuItemDTO> GetItemByIdAsync(int Id);
        Task DeleteItemAsync(int Id);
        Task<int> CreateItemAsync(MenuItemDTO item);
        Task<IEnumerable<MenuItemDTO>> GetMenuItemsByMenuCategoryIdAsync(int categoryId);
    }
}
