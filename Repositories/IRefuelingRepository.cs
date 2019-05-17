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
        ///Ср.цена за литр + ср.расход дт.
        ///Чеки точно
        ///сенсор через автоГРАФ ??
        ///
        Task<IEnumerable<RefuelingSensor>> GetAllRefuelingSensor(IdentityUser identityUser);

        Task<IEnumerable<RefuelingCheck>> GetAllRefuelingCheck(IdentityUser identityUser);

        Task<RefuelingSensor> GetRefuelingSensor(int id);

        Task<RefuelingCheck> GetRefuelingCheck(int id);

        Task<IEnumerable<RefuelingSensor>> GetRefuelingSensorsByDate(DateTime start, DateTime end);

        Task<IEnumerable<RefuelingCheck>> GetRefuelingChecksByDate(DateTime start, DateTime end);

        Task<IEnumerable<RefuelingCheck>> GetTruckRefuelingChecks(Truck truck);

        Task<IEnumerable<RefuelingSensor>> GetTruckRefuelingSensors(Truck truck);

        Task<IEnumerable<RefuelingSensor>> GetDriverRefuelingSensors(Driver driver);

        Task<IEnumerable<RefuelingCheck>> GetDriverRefuelingChecks(Driver driver);

        Task AddRefuelingCheck(RefuelingCheck refuelingCheck);

        Task AddRefuelingSensor(RefuelingSensor refuelingSensor);

        Task AddRangeRefuelingCheck(IEnumerable<RefuelingCheck> refuelingCheck);

        Task AddRangeRefuelingSensor(IEnumerable<RefuelingSensor> refuelingSensor);

        void UpdateRefuelingSensor(RefuelingSensor refuelingSensor);

        void UpdateRefuelingCheck(RefuelingCheck refuelingCheck);

        void DeleteRefuelingSensor(RefuelingSensor refuelingSensor);

        void DeleteRefuelingCheck(RefuelingCheck refuelingCheck);
    }
    
}
