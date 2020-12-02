using AugmentoEmployee.Database.Models;
using AugmentoEmployee.Service.DependentInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugmentoEmployee.Service.Implimentation
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }
        public async Task<Employee> GetRecentEmployee()
        {
            IEnumerable<Employee> obj = await _EmployeeRepository.GetAllEmployees();
            return obj.OrderByDescending(x => x.DOJ).FirstOrDefault();
        }

        public async Task<Employee> GetEmployee(int Id)
        {
            IEnumerable<Employee> obj = await _EmployeeRepository.GetAllEmployees();
            return obj.Where(x => x.Id == Id).SingleOrDefault();
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _EmployeeRepository.GetAllEmployees();
        }
        public async Task<IEnumerable<Employee>> Add(Employee employee)
        {
            return await _EmployeeRepository.Add(employee);
        }
        public async Task<Employee> Update(Employee employee)
        {
            return await _EmployeeRepository.Update(employee);
        }
        public async Task<bool> Delete(int id)
        {
            return await _EmployeeRepository.Delete(id);
        }
    }
}
