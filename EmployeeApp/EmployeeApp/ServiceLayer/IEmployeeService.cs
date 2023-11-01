using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.ServiceLayer
{
    public interface IEmployeeService
    {
        Task<List<Employee>> getEmployeesAsync();
        Task<bool> addEmployeeAsync(Employee employee);
        Task<Employee> getEmployeeByIdAsync(int id);
        Task<bool> updateEmployeeAsync(Employee employee);
        Task<bool> deleteEmployeeAsync(int id);

    }
}
