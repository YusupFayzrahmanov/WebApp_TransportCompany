using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp_TransportCompany.Repositories;
using WebApp_TransportCompany.ViewModels;

namespace WebApp_TransportCompany.Controllers
{
    [Authorize]
    public class SalaryController : Controller
    {
        private readonly IUserRepository _userRepository;

        private readonly ISalaryRepository _salaryRepository;

        private readonly IDriverRepository _driverRepository;

        public SalaryController(IUserRepository userRepository,
            ISalaryRepository salaryRepository, IDriverRepository driverRepository)
        {
            _userRepository = userRepository;
            _salaryRepository = salaryRepository;
            _driverRepository = driverRepository;
        }

        // GET: Order
        public IActionResult IndexSalary(string query)
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalaryFormViewModel vm)
        {
            vm.Salary.Driver = await _driverRepository.GetDriver(vm.DriverId);
            await _salaryRepository.AddSalary(vm.Salary);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int item)
        {
            await _salaryRepository.DeleteSalary(await _salaryRepository.GetSalary(item));
            return Json(Ok());
        }

        public async Task<IActionResult> Details(int id)
        {
            return PartialView("_SalaryDetailsModalPartial",
                await _salaryRepository.GetSalary(id));
        }

        public async Task<IActionResult> Edit(int item)
        {
            return PartialView("_SalaryEditModalPartial",
                await _salaryRepository.GetSalary(item));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SalaryFormViewModel vm)
        {
            vm.Salary.Driver = await _driverRepository.GetDriver(vm.DriverId);
            await _salaryRepository.UpdateSalary(vm.Salary);
            return Redirect(Request.Headers["Referer"].ToString());
        }


    }
}