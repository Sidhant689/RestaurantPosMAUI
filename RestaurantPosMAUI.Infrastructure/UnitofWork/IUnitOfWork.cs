using RestaurantPosMAUI.Domain.Models;
using RestaurantPosMAUI.Infrastructure.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Infrastructure.UnitofWork
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IAuditLogRepository AuditLogs { get; }
        IUserRepository UserRepository { get; }
        IRepository<MenuCategory> MenuCategories { get; }
        IMenuCategoryRepository MenuCategoryRepository { get; }
        IRepository<MenuItem> MenuItems { get; }
        IMenuItemsRepository MenuItemsRepository { get; }
        Task<int> SaveChangesAsync();
        Task<int> CompleteAsync(string userId = null, string action = null);
    }
}
