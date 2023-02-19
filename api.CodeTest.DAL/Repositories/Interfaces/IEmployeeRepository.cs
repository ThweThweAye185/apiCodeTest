using api.CodeTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api.CodeTest.DAL.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
       // Task<Product> GetEmployeeById(string title);
    }
}
