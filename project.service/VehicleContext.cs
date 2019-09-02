using Microsoft.EntityFrameworkCore;
using project.service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.service
{
    public class VehicleContext : DbContext, IVehicleContext
    {

        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        {

        }

        public DbSet<VehicleMake> Vehicles { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
            

          
        }
    }
}