using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testna_instr.Models;

namespace Vehicle.Models
{
/// <summary>
/// viewmodel used inside view which shows list of all vehicle models
/// </summary>
    public class VehiclesModelsViewModel : IVehiclesModelsViewModel
    {
        public List<VehicleModelVM> Vehicles { get; set; }

        public int Count { get; set; }
    }
}
