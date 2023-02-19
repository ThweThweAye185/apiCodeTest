using api.CodeTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api.CodeTest.DAL.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductByName(string name);
    }
}
