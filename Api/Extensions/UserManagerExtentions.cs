using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions
{
    public static class UserManagerExtentions
    {
        public static async Task<AppUser> FindByEmailFromClaimsPrincipleWithAddress(this UserManager<AppUser>
        input,ClaimsPrincipal user){
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)
            ?.Value;
            return await input.Users.Include(x=>x.Address).FirstOrDefaultAsync(x=>x.Email==email);
        }
          public static async Task<AppUser> FindByEmailFromClaimsPrinciples(this UserManager<AppUser>
        input,ClaimsPrincipal user){
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)
            ?.Value;
            return await input.Users.FirstOrDefaultAsync(x=>x.Email==email);
        }
    }
}