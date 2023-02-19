using api.CodeTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api.CodeTest.DAL.Services.Interfaces
{
    public interface IPromotionService
    {
        Task<bool> CreatePromotionAsync(Promotion promotion);
    }
}
