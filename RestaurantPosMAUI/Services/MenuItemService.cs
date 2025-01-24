using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuItem = RestaurantPosMAUI.Models.MenuItem;

namespace RestaurantPosMAUI.Services
{
    internal class MenuItemService
    {
        private readonly ApiService _apiService;

        public MenuItemService()
        {
            _apiService = new ApiService();
        }

        public async Task<MenuItem[]> GetMenuItemsAsync()
        {
            var menuItems =  await _apiService.GetAsync<MenuItem>("GetAllMenuItem");
            return menuItems.ToArray();
        }

        public async Task<MenuItem[]> GetMenuItemsBycategoryId(int categoryId)
        {
            var menuItems = await _apiService.GetAsync<MenuItem>($"GetItemsByCategoryId?catergoryId={categoryId}");
            return menuItems.ToArray();
        }
    }
}
