using RestaurantPosMAUI.Domain.Models;
using RestaurantPosMAUI.Infrastructure.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    { 
        public UserRepository(AppDBContext context) : base(context) { }
    }
}
