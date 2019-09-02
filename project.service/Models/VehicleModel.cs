using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace project.service.Models
{
    public class VehicleModel : IVehicleModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int VehicleMakeId { get; set; }

        public string Abrv { get; set; }

        public  VehicleMake VehicleMake { get; set; }
    }
}
