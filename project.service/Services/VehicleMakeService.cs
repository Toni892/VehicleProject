using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using project.service.Models;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace project.service.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly VehicleContext _context;

        public VehicleMakeService(VehicleContext context)
        {
            _context = context;
        }

       /// <summary>
       /// Add vehicle make to database
       /// </summary>
       /// <param name="vehicle"></param>
        public void AddVehicle(VehicleMake vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }
        /// <summary>
        /// Deletes vehicle make
        /// </summary>
        /// <param name="id"></param>
        public void DeleteVehicle(int id)
        {
            var vehicle = GetVehicle(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// Get vehicle make from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VehicleMake GetVehicle(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            return vehicle;
        }
        /// <summary>
        /// Gets vehicle models from database
        /// </summary>
        /// <param name="skip">how many vehicle  will be skipped when getting (used for pagination)</param>
        /// <param name="take">how many vehicle  will be taken</param>
        /// <param name="searchQuery">search by name param</param>
        /// <param name="sort">asc or desc </param>
        /// <param name="total">result param- how many vehicle model satisfy search criteria</param>
        /// <returns></returns>
        public List<VehicleMake> GetVehicles(int skip,int take, string searchQuery,string sort, out int total)
        {

            var query = _context.Vehicles.AsQueryable();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(x => x.Name.Contains(searchQuery));
            }
            if (sort == "desc")
            {
                query = query.OrderBy(x => x.Name);
            }
            else {
                query = query.OrderByDescending(x => x.Name);
            }
            total = query.Count();
            return query.Skip(skip).Take(take).ToList();
        }
        /// <summary>
        /// Edits one vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        public void Edit(VehicleMake vehicle)
        {
            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();
        }

    }
}
