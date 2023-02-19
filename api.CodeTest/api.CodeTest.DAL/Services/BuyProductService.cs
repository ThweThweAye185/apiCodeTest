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
    public class BuyProductService : IBuyProductService
    {
        private readonly IRepository<BuyProduct> _buyTypeRepository;
        private readonly IMapper _mapper;
        public BuyProductService(IRepository<BuyProduct> buyTypeRepository, IMapper mapper, IBuyProductRepository buyTypeRepo)
        {
            _buyTypeRepository = buyTypeRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<BuyProduct>> GetAll()
        {
            return await _buyTypeRepository.ListAllAsync();
        }
        public Task<BuyProduct> GetBuyTypeById(string id)
        {
            return _buyTypeRepository.GetByIdAsync(id);
        }
        public async Task<bool> CreateBuyTypeAsync(BuyProduct buyType)
        {
            try
            {
                buyType.Id = System.Guid.NewGuid().ToString();
                buyType.Active = true;
                buyType.CreatedBy = "admin";
                buyType.CreatedDate = DateTime.Now;
                buyType.UpdatedDate = DateTime.Now;
                await _buyTypeRepository.AddAsync(buyType);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<bool> UpdateBuyTypeAsync(string id, BuyProduct product)
        {
            try
            {
                BuyProduct buyType = await _buyTypeRepository.GetByIdAsync(id);              
                buyType.UpdatedBy = "admin";
                buyType.UpdatedDate = DateTime.Now;
                await _buyTypeRepository.UpdateAsync(buyType);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<bool> DeleteBuyTypeAsync(string id)
        {
            try
            {
                BuyProduct buyType = await _buyTypeRepository.GetByIdAsync(id);
                await _buyTypeRepository.DeleteAsync(buyType);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
