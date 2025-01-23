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

        public async Task<List<MenuCategory>> GetMenuCategoriesAsync()
        {
            return await _apiService.GetAsync<MenuCategory>("GetAllMenuCategory");
        }
    }

}
