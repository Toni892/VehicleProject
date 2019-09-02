using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using project.service.Models;
using project.service.Services;
using testna_instr.Models;
using Vehicle.Models;

namespace testna_instr.Controllers
{
   
    public class VehicleController : Controller
    {
        private  IVehicleMakeService _vehicleVehicleMake { get; set; }
        private  IMapper mapper { get; set; }

        public VehicleController(IVehicleMakeService vehicleVehicleMake, IMapper mapper)
        {
            _vehicleVehicleMake = vehicleVehicleMake;
            this.mapper = mapper;
        }

        //public IActionResult ActionName()
        //{

        //    //return View(_vehicleVehicleMake.GetVehicles());
        //}
        /// <summary>
        /// Returns list of cehicle models
        /// </summary>
        /// <param name="page">Current page</param>
        /// <param name="searchString">search by name parametar</param>
        /// <param name="sort">asc or desc sorting parameter</param>
        /// <returns></returns>
        public IActionResult Index(int page, string searchString,string sort)
        {
            int total = 0;
            var skip = page == 0 ? 0 : (page - 1) * 10;
            var vehicles = _vehicleVehicleMake.GetVehicles(skip,10, searchString,sort, out total);

            var lista = mapper.Map<List<VehicleViewModel>>(vehicles);
            ViewBag.CurrentFilter = searchString;
            var allVehiclesViewModels = new VehiclesViewModel
            {
                Count = total,
                Vehicles = lista
            };
            return View(allVehiclesViewModels);
        }
        public IActionResult Add()
        {
            return View("AddEdit");
        }
        /// <summary>
        /// Creates new vehicle 
        /// </summary>
        /// <param name="vehicleVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(VehicleViewModel vehicleVM)
        {
            if (ModelState.IsValid)
            {
                var vh = mapper.Map<project.service.Models.VehicleMake>(vehicleVM);
                _vehicleVehicleMake.AddVehicle(vh);
                this.StatusCode(200);
            }
            else
            {
                this.StatusCode(400);
            }

            return RedirectToAction("index");
        }
        /// <summary>
        /// Deletes vehicle 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            var vehicle = _vehicleVehicleMake.GetVehicle(id);
            
            return View(vehicle);
        }
        /// <summary>
        /// Deletes vehicle 
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(VehicleViewModel vehicle)
        {
           
            if (vehicle != null)
            {
                var vh = mapper.Map<List<project.service.Models.VehicleMake>>(new List<VehicleViewModel>() { vehicle });
                _vehicleVehicleMake.DeleteVehicle(vh.First().Id);
            }
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            var vehicle = _vehicleVehicleMake.GetVehicle(id);
            return View("AddEdit",vehicle);
        }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="vehicle"></param>
      /// <returns></returns>
        [HttpPost]
        
        public IActionResult Edit(VehicleViewModel vehicle)
        {
            if (vehicle != null)
            {
                var vh = mapper.Map<project.service.Models.VehicleMake>(vehicle);
                _vehicleVehicleMake.Edit(vh);
            }

            return RedirectToAction("index");
        }
    }
}