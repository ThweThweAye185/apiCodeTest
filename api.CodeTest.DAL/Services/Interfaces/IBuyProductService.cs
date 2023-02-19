using api.CodeTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api.CodeTest.DAL.Services.Interfaces
{
    public interface IBuyProductService 
    {
        Task<IReadOnlyList<BuyProduct>> GetAll();
        Task<BuyProduct> GetBuyTypeById(string id);
        Task<bool> CreateBuyTypeAsync(BuyProduct buyType);
        Task<bool> UpdateBuyTypeAsync(string id, BuyProduct buyType);
        Task<bool> DeleteBuyTypeAsync(string id);
    }
}
