using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RazorPagesMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //To add the seed initializer that we built
            //This...
            /*CreateHostBuilder(args).Build().Run();*/
            //Is replaced with the below code...


            //Get a database context instance(services) from the dependency injection container
                /*var dbcontext = CreateHostBuilder(args).Build().Services.CreateScope().ServiceProvider*/
            var host = CreateHostBuilder(args).Build();  

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    //Call the seedData.Initialize method, passing to it the ServiceProvider instance.
                    //NOTE: In the SeedData class, the dbcontext is accessed using the ServiceProvider...
                    SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
