using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using project.service.Models;
using project.service.Services;
using testna_instr.Models;
using Vehicle.Models;

namespace testna_instr.Controllers
{
    //routes for vehicle model
    public class VehicleModelController : Controller
    {
        private IVehicleModelService _vehicleModel { get; set; }
        private  IVehicleMakeService _vehicleVehicleMake{ get; set; }

    private readonly IMapper mapper;
        public VehicleModelController(IVehicleModelService vehicleModel, IVehicleMakeService vehicleVehicleMake, IMapper mapper)
        {
            _vehicleModel = vehicleModel;
            _vehicleVehicleMake = vehicleVehicleMake;
            this.mapper = mapper;
        }
        /// <summary>
        /// List of vehicle models
        /// </summary>
        /// <param name="page">current page , used for pagination</param>
        /// <param name="searchString">search by name parametar</param>
        /// <param name="sort">asc or desc sorting parameter</param>
        /// <returns></returns>
        public IActionResult Index(int page, string searchString,string sort)
        {
            int total = 0;
            var skip = page == 0 ? 0 : (page - 1) * 10;
            var vehicleModels = _vehicleModel.GetVehicleModels(skip, 10, searchString,sort, out total);

            var lista = mapper.Map<List<VehicleModelVM>>(vehicleModels);
            ViewBag.CurrentFilter = searchString;
            var allVehiclesModelsViewModels = new VehiclesModelsViewModel
            {
                Count = total,
                Vehicles = lista
            };
            return View(allVehiclesModelsViewModels);

        }
        /// <summary>
        /// Detals page of one vehicle model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var model = _vehicleModel.GetVehicleModel(id);
            if (model == null) {
                return NotFound();
            }
            return View(model);
        }

        public IActionResult Add()
        {
         
                var model = new AddVehicleModelVM();
                int total = 0;
                model.Models = new SelectList(_vehicleVehicleMake.GetVehicles(0, 100, null,"asc", out total), "Id", "Name");
            
            return View(model);
        }
        /// <summary>
        /// Creates new vehicle model
        /// </summary>
        /// <param name="vehicleModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(VehicleModelVM vehicleModel)
        {
            if (ModelState.IsValid)
            {
                var vh = mapper.Map<project.service.Models.VehicleModel>(vehicleModel);
                _vehicleModel.Add(vh);
                this.StatusCode(200);
            }
            else {
                this.StatusCode(400);
            }
            return RedirectToAction("index");
        }
        /// <summary>
        /// Edits vehicle model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            var total = 0;
            var vehicleModel = _vehicleModel.GetVehicleModel(id);

            var vehicles = _vehicleVehicleMake.GetVehicles(0, 100, null, "asc", out total);
            var model = new AddVehicleModelVM()
            {
                Models = new SelectList(vehicles, "Id", "Name",vehicleModel.VehicleMakeId),
                Name = vehicleModel.Name,
                Abrv = vehicleModel.Abrv
            };
            return View(model);
        }
        /// <summary>
        /// Edits vehicle model
        /// </summary>
        /// <param name="vehicleModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(VehicleModelVM vehicleModel)
        {
            if (ModelState.IsValid)
            {
                var vh = mapper.Map<project.service.Models.VehicleModel>(vehicleModel);
                _vehicleModel.Edit(vh);
                this.StatusCode(200);
            }
            else {
                this.StatusCode(400);
            }
            return RedirectToAction("index");
        }
        /// <summary>
        /// Deletes vehicle model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            var model = _vehicleModel.GetVehicleModel(id);
            return View(model);
        }
        /// <summary>
        /// Deletes vehicle models
        /// </summary>
        /// <param name="vehicleModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(VehicleModel vehicleModel)
        {
            _vehicleModel.Delete(vehicleModel);
            return RedirectToAction("Index");
        }
    }
}