using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testna_instr.Models;

namespace Vehicle.Models
{
/// <summary>
/// Models used for view which shows all vehicle models
/// </summary>
    public class VehiclesViewModel : IVehiclesViewModel
    {
        public List<VehicleViewModel> Vehicles { get; set; }

        public int Count { get; set; }
    }

}
