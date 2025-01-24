using RestaurantPosMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Services
{
    public class MenuCategoryService
    {
        private readonly ApiService _apiService;

        public MenuCategoryService()
        {
            _apiService = new ApiService();
        }

        public async Task<MenuCategory[]> GetMenuCategoriesAsync()
        {
            var categories = await _apiService.GetAsync<MenuCategory>("GetAllMenuCategory");
            return categories.ToArray();
        }
    }

}
