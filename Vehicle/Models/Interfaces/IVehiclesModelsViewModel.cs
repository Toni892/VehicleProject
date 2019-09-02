using System.Collections.Generic;
using testna_instr.Models;

namespace Vehicle.Models
{
    public interface IVehiclesModelsViewModel
    {
        int Count { get; set; }
        List<VehicleModelVM> Vehicles { get; set; }
    }
}