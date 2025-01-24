using Microsoft.EntityFrameworkCore;
using RestaurantPosMAUI.Domain.Models;
using RestaurantPosMAUI.Infrastructure.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Infrastructure.Repositories
{
    public class MenuItemrepository : Repository<MenuItem>, IMenuItemsRepository
    {
        public MenuItemrepository(AppDBContext context) : base (context)
        {


            
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItemsByMenuCategoryIdAsync(int menuCategoryId)
        {
            return await _context.MenuItemCategoriesMapping
                .Where(mapping => mapping.MenuCategoryId == menuCategoryId)
                .Select(mapping => mapping.MenuItem)
                .ToListAsync();
        }
    }
}
