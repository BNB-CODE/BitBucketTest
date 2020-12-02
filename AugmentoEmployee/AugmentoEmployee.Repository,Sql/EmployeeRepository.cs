using AugmentoEmployee.Database.Models;
using AugmentoEmployee.Service.DependentInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AugmentoEmployee.Repository_Sql
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly AppDBContext _dbContext;

        public EmployeeRepository(AppDBContext context)
        {
            _dbContext = context;

        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var dt = await _dbContext.Employees.Where(x => x.IsDeleted == false).ToListAsync();
            IEnumerable<Employee> Data = new List<Employee>();
            if (dt.Count() > 0)
            {
                Data = dt;
            }
            return Data;
        }
        public async Task<IEnumerable<Employee>> Add(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            var dt = await _dbContext.Employees.Where(x => x.IsDeleted == false).ToListAsync();
            return dt;
        }
        public async Task<Employee> Update(Employee employee)
        {
            Employee Empobj = await _dbContext.Employees.Where(x => x.Id == employee.Id).SingleOrDefaultAsync();
            Empobj.Name = employee.Name;
            Empobj.IsDeleted = employee.IsDeleted;
            Empobj.Email = employee.Email;
            Empobj.ModifiedDate = DateTime.Now;
            _dbContext.Employees.Update(Empobj);
            await _dbContext.SaveChangesAsync();
            return Empobj;
        }
        public async Task<bool> Delete(int id)
        {
            bool isDeleted = false;
            Employee Empobj = await _dbContext.Employees.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (Empobj != null)
            {
                Empobj.IsDeleted = true;
                Empobj.ModifiedDate = DateTime.Now;
                _dbContext.Employees.Update(Empobj);
                // _dbContext.empployees.Remove(Empobj);
                await _dbContext.SaveChangesAsync();
                isDeleted = true;
            }

            return isDeleted;
        }
    }
}
