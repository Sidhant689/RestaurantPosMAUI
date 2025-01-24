using RestaurantPosMAUI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Infrastructure.InterfaceRepositories
{
    public interface IMenuItemsRepository : IRepository<MenuItem>
    {
        Task<IEnumerable<MenuItem>> GetMenuItemsByMenuCategoryIdAsync(int menuCategoryId);
    }
}
