using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Casvean_IlieSebastian_Laborator2.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Casvean_IlieSebastian_Laborator2
{
    public class Program
    {
        private static ILogger<Program> logger;
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<LibraryContext>();
                    DatabaseInitialization.Initialize(context);
                }
                catch (Exception e)
                {
                    logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "An error occured");
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
