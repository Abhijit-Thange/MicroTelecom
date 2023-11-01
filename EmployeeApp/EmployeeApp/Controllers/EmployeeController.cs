using EmployeeApp.Models;
using EmployeeApp.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public EmployeeController() { }

        // GET: Employee
        public async Task<ActionResult> Index()
        {
            var emp = await _employeeService.getEmployeesAsync();
            return View(emp);
        }

        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var add = await _employeeService.addEmployeeAsync(employee);
                if (add)
                    TempData["message"] = "Employee Added Succesfully";
                else
                    TempData["message"] = "Employee Not Added";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<ActionResult> EditEmployeeInfo(int Id)
        {
            var employee = await _employeeService.getEmployeeByIdAsync(Id);
            return View(employee);
        }

        [HttpPost]
        public async Task<ActionResult> EditEmployeeInfo(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var edit = await _employeeService.updateEmployeeAsync(employee);
                if (edit)
                    TempData["message"] = "Employee Updated Succesfully";
                else
                    TempData["message"] = "Employee Not Updated";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<ActionResult> DeleteEmployee(int Id)
        {
            var employee = await _employeeService.getEmployeeByIdAsync(Id);
            return View(employee);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public async Task<ActionResult> Delete(int Id)
        {
            var delete = await _employeeService.deleteEmployeeAsync(Id);
            if (delete)
                TempData["message"] = "Employee Deleted Succesfully";
            else
                TempData["message"] = "Employee Not Deleted";
            return RedirectToAction("Index");
        }
    }
}