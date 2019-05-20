using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.Repositories
{
    public interface ISalaryRepository
    {
        Task<IEnumerable<Salary>> GetSalaries(IdentityUser user);

        Task<IEnumerable<Salary>> GetDirverSalaries(Driver driver);

        Task<IEnumerable<Salary>> GetSalariesByDate(DateTime start, DateTime end);

        Task<Salary> GetSalary(int id);

        Task AddSalary(Salary salary);

        Task DeleteSalary(Salary salary);

        Task UpdateSalary(Salary salary);
    }
}
