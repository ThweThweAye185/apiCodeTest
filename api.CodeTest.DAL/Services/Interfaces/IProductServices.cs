using api.CodeTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api.CodeTest.DAL.Services.Interfaces
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetAll();
        Task<Product> GetProductById(string id);
        Task<bool> CreateProductAsync(Product customer);
        Task<bool> UpdateProductAsync(string id, Product customer);
        Task<bool> DeleteProductAsync(string id);
        Task<Product> GetProductDetailByName(string name);
    }
}
