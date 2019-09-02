using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testna_instr.Models
{
    public class AddVehicleModelVM
    {

        public string Name { get; set; }

        //public project.service.Models.VehicleMake VehicleMake { get; set; }

        public SelectList Models{ get; set; }

        public int VehicleMakeId { get; set; }

        public string Abrv { get; set; }

    }
}
