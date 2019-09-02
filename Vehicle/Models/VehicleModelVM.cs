using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testna_instr.Models
{
/// <summary>
/// view model used inside view which shows one or more vehicle models
/// </summary>
    public class VehicleModelVM : IVehicleModelVM
    {
        public string Name { get; set; }

        public string Abrv { get; set; }
        public int VehicleMakeId { get; set; }

        public int Id { get; set; }

        public VehicleViewModel VehicleMake { get; set; }
    }
}
