using AutoMapper;
using project.service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Models;

namespace testna_instr.Models
{
    public class AutoMapperClass:Profile
    {
        public AutoMapperClass()
        {
            CreateMap<VehicleMake, VehicleViewModel>();
            CreateMap<VehicleViewModel, VehicleMake>();
            CreateMap<VehicleModelVM, VehicleModel>();
            CreateMap<VehicleModel, VehicleModelVM>();
        }
    }
}
