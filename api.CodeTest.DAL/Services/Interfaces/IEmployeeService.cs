using api.CodeTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api.CodeTest.DAL.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IReadOnlyList<Employee>> GetAll();
        Task<Employee> GetEmployeeById(string id);
        Task<bool> CreateEmployeeAsync(Employee customer);
        Task<bool> UpdateEmployeeAsync(string id, Employee customer);
        Task<bool> DeleteEmployeeAsync(string id);
        Task<Employee> GetProductDetailByTitle(string title);
    }
}
