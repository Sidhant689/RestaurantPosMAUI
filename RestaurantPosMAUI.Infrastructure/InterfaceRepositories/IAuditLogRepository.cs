using RestaurantPosMAUI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Infrastructure.InterfaceRepositories
{
    public interface IAuditLogRepository : IRepository<AuditLog>
    {
        Task AddLogAsync(AuditLog auditLog);
    }
}
