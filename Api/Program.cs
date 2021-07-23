using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Identity;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var serviceproviders = scope.ServiceProvider;
                var loggerfactory =
                    serviceproviders.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context =
                        serviceproviders.GetRequiredService<StoreContext>();
                    await context.Database.MigrateAsync();
                    await StoreContextSeed.SeedData(context, loggerfactory);

                    var usermanager =
                        serviceproviders
                            .GetRequiredService<UserManager<AppUser>>();

                    var IdentityContext =
                        serviceproviders
                            .GetRequiredService<AppIdentityDBContext>();
                    await IdentityContext.Database.MigrateAsync();
                    await AppIdentitySeedData.SeedData(usermanager);
                }
                catch (Exception ex)
                {
                    var logger = loggerfactory.CreateLogger<Program>();
                    logger.LogError(ex, "An Error ocurred during migrations");
                }
                host.Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
