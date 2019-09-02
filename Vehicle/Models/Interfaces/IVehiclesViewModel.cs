using System.Collections.Generic;
using testna_instr.Models;

namespace Vehicle.Models
{
    public interface IVehiclesViewModel
    {
        int Count { get; set; }
        List<VehicleViewModel> Vehicles { get; set; }
    }
}