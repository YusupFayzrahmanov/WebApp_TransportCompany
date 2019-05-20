using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApp_TransportCompany.Data;

namespace WebApp_TransportCompany.Repositories
{
    public class UserRepository:BaseRepository, IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserRepository(ApplicationDbContext context, UserManager<IdentityUser> userManager)
            :base(context)
        {
            _userManager = userManager;
        }

        public async Task<IdentityUser> GetIdentityUser(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }
    }
}
