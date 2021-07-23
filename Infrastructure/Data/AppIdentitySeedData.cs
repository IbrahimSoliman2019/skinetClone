using System.Linq;
using System.Threading.Tasks;
using Core.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data
{
    public class AppIdentitySeedData
    {
        public static async Task SeedData(UserManager<AppUser> userManager)
        {

            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Ibrahim",
                    Email = "ib@ib.com",
                    UserName = "ib@ib.com",
                    Address=new Address{
                        FirstName="hh",
                        LastName="hhhhh",
                        Street="10 the street",
                        City="zag",
                        State="sh",
                        ZipCode="8393"
                    }
            

                };
               await  userManager.CreateAsync(user,"Pa$swo7d");
                }

        }
    }
}