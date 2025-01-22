using RestaurantPosMAUI.Domain.Models.Auth;
using RestaurantPosMAUI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Application.Auth
{
    public interface IJwtService
    {
        Token GenerateToken(User user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
