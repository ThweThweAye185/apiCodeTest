using api.CodeTest.DAL.Models;
using api.CodeTest.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api.CodeTest.DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }
        public Task<Product> GetProductByName(string name)
        {
            return _context.Product.FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}
