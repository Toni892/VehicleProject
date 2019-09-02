using Microsoft.EntityFrameworkCore;
using project.service.Models;

namespace project.service
{
    public interface IVehicleContext
    {
        DbSet<VehicleModel> VehicleModels { get; set; }
        DbSet<VehicleMake> Vehicles { get; set; }
    }
}