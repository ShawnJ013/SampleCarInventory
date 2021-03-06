﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DealerShip.Data;
using DealerShip.Models;

namespace DealerShip.Controllers
{
    [Produces("application/json")]
    [Route("api/Vehicles")]
    public class VehiclesController : Controller
    {
        private readonly VehiclesContext _context;

        public VehiclesController(VehiclesContext context)
        {
            _context = context;
        }

        // GET: api/Vehicles
        [HttpGet]
        public IEnumerable<Vehicles> GetVehicles()
        {
            return _context.Vehicles;
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicles([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicles = await _context.Vehicles.SingleOrDefaultAsync(m => m.Id == id);

            if (vehicles == null)
            {
                return NotFound();
            }

            return Ok(vehicles);
        }


        //CarSearch Criteria
        [Route("api/Vehicles/Search")]
        [HttpGet]
        public IQueryable<Vehicles> SearchVehicles(SearchVehicle search)  
        {
            IQueryable<Vehicles> allVehicles = _context.Vehicles;

            if (search.Make != null)
            {
                allVehicles = allVehicles.Where(r => r.Make == search.Make);
            }

            if (search.Year != null)
            {
                allVehicles = allVehicles.Where(r => r.Year == search.Year);
            }

            if (search.Color != null)
            {
                allVehicles = allVehicles.Where(r => r.Color == search.Color);
            }

            //if (search.FilterPrice > 0)
            //{
            //    allVehicles = allVehicles.Where(r => r.Price <= search.FilterPrice);
            //}

            if (search.HasSunRoof != null)
            {
                allVehicles = allVehicles.Where(r => r.HasSunRoof == search.HasSunRoof);
            }

            if (search.IsFourWheelDrive != null)
            {
                allVehicles = allVehicles.Where(r => r.IsFourWheelDrive == search.IsFourWheelDrive);
            }

            if (search.HaslowMiles != null)
            {
                allVehicles = allVehicles.Where(r => r.HaslowMiles == search.HaslowMiles);
            }

            if (search.HasPowerWindows != null)
            {
                allVehicles = allVehicles.Where(r => r.HasPowerWindows == search.HasPowerWindows);
            }

            if (search.HasNavigation != null)
            {
                allVehicles = allVehicles.Where(r => r.HasNavigation == search.HasNavigation);
            }

            if (search.HasHeatedSeats != null)
            {
                allVehicles = allVehicles.Where(r => r.HasHeatedSeats == search.HasHeatedSeats);
            }



            return allVehicles;
        }

        // PUT: api/Vehicles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicles([FromRoute] int id, [FromBody] Vehicles vehicles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicles.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehicles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiclesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vehicles
        [HttpPost]
        public async Task<IActionResult> PostVehicles([FromBody] Vehicles vehicles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Vehicles.Add(vehicles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicles", new { id = vehicles.Id }, vehicles);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicles([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicles = await _context.Vehicles.SingleOrDefaultAsync(m => m.Id == id);
            if (vehicles == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicles);
            await _context.SaveChangesAsync();

            return Ok(vehicles);
        }

        private bool VehiclesExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}