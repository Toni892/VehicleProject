using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using project.service.Models;

namespace project.service.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly VehicleContext _context;

        public VehicleModelService(VehicleContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Adds vehicle model to database
        /// </summary>
        /// <param name="vehicleModel"></param>
        public void Add(VehicleModel vehicleModel)
        {

            _context.VehicleModels.Add(vehicleModel);

            _context.SaveChanges();
        }
        /// <summary>
        /// Edits one vehicle mdel
        /// </summary>
        /// <param name="vehicleModel"></param>
        public void Edit(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Update(vehicleModel);
            _context.SaveChanges();
        }
        /// <summary>
        /// Gets one vehicle model from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VehicleModel GetVehicleModel(int id)
        {
            var vm = _context.VehicleModels.Include(x => x.VehicleMake)
            .Where(x => x.Id == id).FirstOrDefault();


            return vm;
        }
        /// <summary>
        /// Gets vehicle models from database
        /// </summary>
        /// <param name="skip">how many vehicle models will be skipped when getting (used for pagination)</param>
        /// <param name="take">how many vehicle models will be taken</param>
        /// <param name="searchQuery">search by name param</param>
        /// <param name="sort">asc or desc </param>
        /// <param name="total">result param- how many vehicle model satisfy search criteria</param>
        /// <returns></returns>
        public List<VehicleModel> GetVehicleModels(int skip, int take, string searchQuery,string sort, out int total)
        {
            var query = _context.VehicleModels.Include("VehicleMake");
            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(x => x.Name.Contains(searchQuery));
            }
            if (sort == "desc")
            {
                query = query.OrderBy(x => x.Name);
            }
            else
            {
                query = query.OrderByDescending(x => x.Name);
            }
            total = query.Count();
            var vms = query.Skip(skip).Take(take).ToList();

            return vms;
        }
        //delete vehicle model from db
        public void Delete(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Remove(vehicleModel);
            _context.SaveChanges();
        }
    }
}