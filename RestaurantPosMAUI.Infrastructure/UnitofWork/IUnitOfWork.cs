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
        Task<int> SaveChangesAsync();
        Task<int> CompleteAsync(string userId = null, string action = null);
    }
}
