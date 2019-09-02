using project.service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.service.Services
{
    public interface IVehicleMakeService
    {
        void AddVehicle(VehicleMake vehicle);
        void Edit(VehicleMake vehicle);
        void DeleteVehicle(int id);
        VehicleMake GetVehicle(int id);
        List<VehicleMake> GetVehicles(int skip,int take,string searchQuery,string sort,out int total);
    }
}