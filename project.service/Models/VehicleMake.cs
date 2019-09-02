using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace project.service.Models
{
    public class VehicleMake : IVehicleMake
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
