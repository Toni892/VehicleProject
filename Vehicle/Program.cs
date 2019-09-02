using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using project.service;
using Microsoft.EntityFrameworkCore;
using project.service.Models;

namespace testna_instr
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var host = CreateWebHostBuilder(args).Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<VehicleContext>();
                context.Database.Migrate();
            }

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    // Requires using RazorPagesMovie.Models;
                    var context = services.GetService<VehicleContext>();
                    if (context.Vehicles.Count() == 0)
                    {
                        context.Add(new VehicleMake
                        {
                            Name = "Renault",
                            Abrv = "REN",

                        });
                        context.Add(new VehicleMake
                        {
                            Name = "Ford",
                            Abrv = "FOR",

                        });
                        context.Add(new VehicleMake
                        {
                            Name = "Citroen",
                            Abrv = "CIT",

                        });

                        var peugot = new VehicleMake
                        {
                            Name = "Peugeot",
                            Abrv = "PEU",

                        };
                        context.Add(peugot);
                        context.VehicleModels.Add(new VehicleModel
                        {
                            Name = "3008",
                            Abrv = "3008",
                            VehicleMakeId = peugot.Id

                        });
                    }
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
