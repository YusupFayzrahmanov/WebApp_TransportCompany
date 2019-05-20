using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApp_TransportCompany.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityUser> GetIdentityUser(ClaimsPrincipal user);
    }
}
