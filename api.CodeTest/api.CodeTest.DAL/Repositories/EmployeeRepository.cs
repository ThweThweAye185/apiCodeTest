using api.CodeTest.DAL.Models;
using api.CodeTest.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
