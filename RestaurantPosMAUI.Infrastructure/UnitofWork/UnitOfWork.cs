using Microsoft.EntityFrameworkCore;
using RestaurantPosMAUI.Domain.Models;
using RestaurantPosMAUI.Infrastructure.InterfaceRepositories;
using RestaurantPosMAUI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Infrastructure.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;
        public IRepository<User> Users { get; }

        public IAuditLogRepository AuditLogs { get; }
        public IUserRepository UserRepository { get; }

        public IRepository<MenuCategory> MenuCategories { get; }
        public IMenuCategoryRepository MenuCategoryRepository { get; }

        public IRepository<MenuItem> MenuItems { get; }
        public IMenuItemsRepository MenuItemsRepository { get; }

        public UnitOfWork(AppDBContext context)
        {
            _context = context;
            Users = new Repository<User>(context);
            AuditLogs = new AuditLogRepository(context);
            UserRepository = new UserRepository(context);

            MenuCategories = new MenuCategoryRepository(context);
            MenuCategoryRepository = new MenuCategoryRepository(context);

            MenuItems = new MenuItemrepository(context);
            MenuItemsRepository = new MenuItemrepository(context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CompleteAsync(string userId = null, string action = null)
        {
            var changes = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted)
                .Select(e => new
                {
                    EntityName = e.Entity.GetType().Name,
                    Action = e.State.ToString(),
                    EntityId = e.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.CurrentValue?.ToString(),
                    Changes = e.Properties.Where(p => e.State == EntityState.Modified && p.IsModified)
                        .Select(p => new { p.Metadata.Name, OldValue = p.OriginalValue, NewValue = p.CurrentValue })
                        .ToList()
                }).ToList();

            if (changes.Any() && !string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(action))
            {
                foreach (var change in changes)
                {
                    await AuditLogs.AddLogAsync(new AuditLog
                    {
                        UserId = userId,
                        Action = action,
                        EntityName = change.EntityName,
                        EntityId = change.EntityId,
                        Timestamp = DateTime.UtcNow,
                        Changes = JsonSerializer.Serialize(change.Changes)
                    });
                }
            }

            return await SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
