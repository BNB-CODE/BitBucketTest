using AugmentoEmployee.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AugmentoEmployee.Service.DependentInterface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<IEnumerable<Employee>> Add(Employee employee);
        Task<Employee> Update(Employee employee);
        Task<bool> Delete(int id);
    }
}
