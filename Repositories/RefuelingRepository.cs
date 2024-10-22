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
    public class RefuelingRepository:BaseRepository,IRefuelingRepository
    {
        public RefuelingRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task AddRangeRefuelingCheck(IEnumerable<RefuelingCheck> refuelingCheck)
        {
            await _context.RefuelingsCheck.AddRangeAsync(refuelingCheck);
            await Save();
        }

        public async Task AddRangeRefuelingReport(IEnumerable<RefuelingReport> refuelingReport)
        {
            await _context.RefuelingReports.AddRangeAsync(refuelingReport);
            await Save();
        }

        public async Task AddRangeRefuelingSensor(IEnumerable<RefuelingSensor> refuelingSensor)
        {
            await _context.RefuelingsSensor.AddRangeAsync(refuelingSensor);
            await Save();
        }

        public async Task AddRefuelingCheck(RefuelingCheck refuelingCheck)
        {
            await _context.RefuelingsCheck.AddAsync(refuelingCheck);
            await Save();
        }

        public async Task AddRefuelingReport(RefuelingReport refuelingReport)
        {
            await _context.RefuelingReports.AddAsync(refuelingReport);
            await Save();
        }

        public async Task AddRefuelingSensor(RefuelingSensor refuelingSensor)
        {
            await _context.RefuelingsSensor.AddAsync(refuelingSensor);
            await Save();
        }

        public async Task AddTatneftCard(TatneftCard tatneftCard)
        {
            await _context.TatneftCards.AddAsync(tatneftCard);
            await Save();
        }

        public async Task DeleteRefuelingCheck(RefuelingCheck refuelingCheck)
        {
            _context.RefuelingsCheck.Remove(refuelingCheck);
            await Save();
        }

        public async Task DeleteRefuelingReport(RefuelingReport refuelingReport)
        {
            _context.RefuelingReports.Remove(refuelingReport);
            await Save();
        }

        public async Task DeleteRefuelingSensor(RefuelingSensor refuelingSensor)
        {
            _context.RefuelingsSensor.Remove(refuelingSensor);
            await Save();
        }

        public async Task DeleteTatneftCard(int id)
        {
            _context.TatneftCards.Remove(await _context.TatneftCards.FindAsync(id));
            await Save();
        }

        public async Task<IEnumerable<RefuelingCheck>> GetAllRefuelingCheck(IdentityUser identityUser)
        {
            return await _context.RefuelingsCheck
                .Include(x => x.Truck)
                .ToListAsync();
        }

        public async Task<IEnumerable<RefuelingReport>> GetAllRefuelingReport(IdentityUser identityUser)
        {
            return await _context.RefuelingReports
                .Include(x => x.Driver)
                .Include(x => x.Truck)
                .ToListAsync();
        }

        public async Task<IEnumerable<RefuelingSensor>> GetAllRefuelingSensor(IdentityUser identityUser)
        {
            return await _context.RefuelingsSensor
                .Include(x => x.Truck)
                .ToListAsync();
        }

        public Task<IEnumerable<RefuelingCheck>> GetDriverRefuelingChecks(Driver driver)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<RefuelingCheck>> GetDriverRefuelingChecks(Driver driver)
        //{
        //    return await _context.RefuelingsCheck
        //        .Include(x => x.Truck)
        //        .Where(x => x.Driver.Id == driver.Id)
        //        .ToListAsync();
        //}

        public async Task<IEnumerable<RefuelingReport>> GetDriverRefuelingReport(Driver driver)
        {
            return await _context.RefuelingReports
                .Include(x => x.Driver)
                .Include(x => x.Truck)
                .Where(x => x.Driver.Id == driver.Id)
                .ToListAsync();
        }

        public Task<IEnumerable<RefuelingSensor>> GetDriverRefuelingSensors(Driver driver)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<RefuelingSensor>> GetDriverRefuelingSensors(Driver driver)
        //{
        //    return await _context.RefuelingsSensor
        //        .Include(x => x.Truck)
        //        .Where(x => x.Driver.Id == driver.Id)
        //        .ToListAsync();
        //}

        public async Task<RefuelingCheck> GetRefuelingCheck(int id)
        {
            return await _context.RefuelingsCheck
                .Include(x => x.Truck)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<RefuelingCheck>> GetRefuelingChecksByDate(DateTime start, DateTime end)
        {
            return await _context.RefuelingsCheck
                .Include(x => x.Truck)
                .Where(x => x.RefuelDate >= start && x.RefuelDate <= end)
                .ToListAsync();
        }

        public async Task<RefuelingReport> GetRefuelingReport(int id)
        {
            return await _context.RefuelingReports
                .Include(x => x.Driver)
                .Include(x => x.Truck)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<RefuelingReport>> GetRefuelingReportByDate(DateTime start, DateTime end)
        {
            return await _context.RefuelingReports
               .Include(x => x.Driver)
               .Include(x => x.Truck)
               .Where(x => x.RefuelDate >= start && x.RefuelDate <= end)
               .ToListAsync();
        }

        public async Task<RefuelingSensor> GetRefuelingSensor(int id)
        {
            return await _context.RefuelingsSensor
                .Include(x => x.Truck)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<RefuelingSensor>> GetRefuelingSensorsByDate(DateTime start, DateTime end)
        {
            return await _context.RefuelingsSensor
               .Include(x => x.Truck)
               .Where(x => x.RefuelDate >= start && x.RefuelDate <= end)
               .ToListAsync();
        }

        public async Task<TatneftCard> GetTatneftCard(int id)
        {
            return await _context.TatneftCards
                .Include(x => x.Drivers)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TatneftCard>> GetTatneftCards(IdentityUser identityUser)
        {
            return await _context.TatneftCards
                .Include(x => x.Drivers)
                .ToListAsync();
        }

        public async Task<IEnumerable<RefuelingCheck>> GetTruckRefuelingChecks(Truck truck)
        {
            return await _context.RefuelingsCheck
                .Include(x => x.Truck)
                .Where(x => x.Truck.Id == truck.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<RefuelingReport>> GetTruckRefuelingReport(Truck truck)
        {
            return await _context.RefuelingReports
                .Include(x => x.Driver)
                .Include(x => x.Truck)
                .Where(x => x.Truck.Id == truck.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<RefuelingSensor>> GetTruckRefuelingSensors(Truck truck)
        {
            return await _context.RefuelingsSensor
                .Include(x => x.Truck)
                .Where(x => x.Truck.Id == truck.Id)
                .ToListAsync();
        }

        public async Task UpdateRefuelingCheck(RefuelingCheck refuelingCheck)
        {
            _context.RefuelingsCheck.Update(refuelingCheck);
            await Save();
        }

        public async Task UpdateRefuelingReport(RefuelingReport refuelingCheck)
        {
            _context.RefuelingReports.Update(refuelingCheck);
            await Save();
        }

        public async Task UpdateRefuelingSensor(RefuelingSensor refuelingSensor)
        {
            _context.RefuelingsSensor.Update(refuelingSensor);
            await Save();
        }

        public async Task UpdateTatneftCard(TatneftCard tatneftCard)
        {
            _context.TatneftCards.Update(tatneftCard);
            await Save();
        }

        public async Task<TatneftCard> GetTatneftCardByNumber(string number)
        {
            return await _context.TatneftCards
                .FirstOrDefaultAsync(x => x.Number == number);
        }
    }
}
