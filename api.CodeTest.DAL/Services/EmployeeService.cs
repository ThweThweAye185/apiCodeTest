using api.CodeTest.DAL.Models;
using api.CodeTest.DAL.Repositories.Interfaces;
using api.CodeTest.DAL.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api.CodeTest.DAL.Services
{
    public class EmployeeService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepo;
        public EmployeeService(IRepository<Product> porductRepository, IMapper mapper, IProductRepository productRepo)
        {
            _productRepository = porductRepository;
            _mapper = mapper;
            _productRepo = productRepo;
        }
        public async Task<IReadOnlyList<Product>> GetAll()
        {
            return await _productRepository.ListAllAsync();
        }
        public Task<Product> GetProductById(string id)
        {
            return _productRepository.GetByIdAsync(id);
        }

        public Task<Product> GetProductDetailByName(string name)
        {
            return _productRepo.GetProductByName(name);
        }
        public async Task<bool> CreateProductAsync(Product product)
        {
            try
            {
                product.Id = System.Guid.NewGuid().ToString();
                //product.IsAvailable = true;
                product.Active = true;
                product.CreatedBy = "admin";
                product.CreatedDate = DateTime.Now;
                product.UpdatedDate = DateTime.Now;
                await _productRepository.AddAsync(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<bool> UpdateProductAsync(string id, Product product)
        {
            try
            {
                Product prod = await _productRepository.GetByIdAsync(id);
                prod.Active =false;
                //prod.IsAvailable = product.IsAvailable;
                prod.UpdatedBy = "admin";
                prod.UpdatedDate = DateTime.Now;
                await _productRepository.UpdateAsync(prod);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<bool> DeleteProductAsync(string id)
        {
            try
            {
                Product product = await _productRepository.GetByIdAsync(id);
                await _productRepository.DeleteAsync(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
