﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp_TransportCompany.Data;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.Repositories
{
    public class TruckRepository:BaseRepository, ITruckRepository
    {
        public TruckRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task AddTruck(Truck truck)
        {
            await _context.Trucks.AddAsync(truck);
        }

        public void DeleteTruck(Truck truck)
        {
            _context.Trucks.Remove(truck);
        }

        public async Task<Truck> GetTruck(int id)
        {
            return await _context.Trucks
                .Include(x => x.Drivers)
                .Include(x => x.Orders)
                .Include(x => x.RefuelingChecks)
                .Include(x => x.RefuelingSensors)
                .Include(x => x.Repairs)
                .Include(x => x.Wheels)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Truck>> GetTrucks(IdentityUser user)
        {
            return await _context.Trucks
                .Include(x => x.Drivers)
                .Include(x => x.Orders)
                .Include(x => x.RefuelingChecks)
                .Include(x => x.RefuelingSensors)
                .Include(x => x.Repairs)
                .Include(x => x.Wheels)
                .Where(x => x.IsActual && x.Identity.Id == user.Id)
                .ToListAsync();
        }

        public void UpdateTruck(Truck truck)
        {
            _context.Trucks.Update(truck);
        }
    }
}