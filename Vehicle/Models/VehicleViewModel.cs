using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testna_instr.Models
{
    /// <summary>
    /// Model used for view which represents vehicle make
    /// </summary>
    public class VehicleViewModel : IVehicleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
