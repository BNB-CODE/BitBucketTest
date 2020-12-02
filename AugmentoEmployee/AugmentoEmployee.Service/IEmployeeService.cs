using AugmentoEmployee.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AugmentoEmployee.Service
{
    public interface IEmployeeService
    {
        Task<Employee> GetRecentEmployee();
        Task<Employee> GetEmployee(int Id);
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<IEnumerable<Employee>> Add(Employee employee);
        Task<Employee> Update(Employee employee);
        Task<bool> Delete(int id);
    }
}
