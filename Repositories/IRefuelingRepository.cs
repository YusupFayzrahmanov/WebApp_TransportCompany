using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.Repositories
{
    public interface IRefuelingRepository
    {
        Task<IEnumerable<RefuelingSensor>> GetAllRefuelingSensor(IdentityUser identityUser);

        Task<IEnumerable<RefuelingCheck>> GetAllRefuelingCheck(IdentityUser identityUser);

        Task<IEnumerable<RefuelingReport>> GetAllRefuelingReport(IdentityUser identityUser);

        Task<RefuelingSensor> GetRefuelingSensor(int id);

        Task<RefuelingCheck> GetRefuelingCheck(int id);

        Task<RefuelingReport> GetRefuelingReport(int id);

        Task<IEnumerable<RefuelingSensor>> GetRefuelingSensorsByDate(DateTime start, DateTime end);

        Task<IEnumerable<RefuelingCheck>> GetRefuelingChecksByDate(DateTime start, DateTime end);

        Task<IEnumerable<RefuelingReport>> GetRefuelingReportByDate(DateTime start, DateTime end);

        Task<IEnumerable<RefuelingCheck>> GetTruckRefuelingChecks(Truck truck);

        Task<IEnumerable<RefuelingSensor>> GetTruckRefuelingSensors(Truck truck);

        Task<IEnumerable<RefuelingReport>> GetTruckRefuelingReport(Truck truck);

        Task<IEnumerable<RefuelingSensor>> GetDriverRefuelingSensors(Driver driver);

        Task<IEnumerable<RefuelingCheck>> GetDriverRefuelingChecks(Driver driver);

        Task<IEnumerable<RefuelingReport>> GetDriverRefuelingReport(Driver driver);

        Task AddRefuelingCheck(RefuelingCheck refuelingCheck);

        Task AddRefuelingSensor(RefuelingSensor refuelingSensor);

        Task AddRefuelingReport(RefuelingReport refuelingReport);

        Task AddRangeRefuelingCheck(IEnumerable<RefuelingCheck> refuelingCheck);

        Task AddRangeRefuelingSensor(IEnumerable<RefuelingSensor> refuelingSensor);

        Task AddRangeRefuelingReport(IEnumerable<RefuelingReport> refuelingReport);

        Task UpdateRefuelingSensor(RefuelingSensor refuelingSensor);

        Task UpdateRefuelingCheck(RefuelingCheck refuelingCheck);

        Task UpdateRefuelingReport(RefuelingReport refuelingCheck);

        Task DeleteRefuelingSensor(RefuelingSensor refuelingSensor);

        Task DeleteRefuelingCheck(RefuelingCheck refuelingCheck);

        Task DeleteRefuelingReport(RefuelingReport refuelingReport);

        Task<IEnumerable<TatneftCard>> GetTatneftCards(IdentityUser identityUser);

        Task<TatneftCard> GetTatneftCard(int id);

        Task<TatneftCard> GetTatneftCardByNumber(string number);

        Task AddTatneftCard(TatneftCard tatneftCard);

        Task UpdateTatneftCard(TatneftCard tatneftCard);

        Task DeleteTatneftCard(int id);
    }
    
}
