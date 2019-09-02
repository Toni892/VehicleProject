using project.service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.service.Services
{
    public interface IVehicleModelService
    {
        void Add(VehicleModel vehicleModel);
        VehicleModel GetVehicleModel(int id);
        List<VehicleModel> GetVehicleModels(int skip, int take, string searchQuery,string sort, out int total);
        void Edit(VehicleModel vehicleModel);
        void Delete(VehicleModel vehicleModel);

    }
}
