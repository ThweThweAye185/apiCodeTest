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
    public class PromotionService : IPromotionService
    {
        private readonly IRepository<Promotion> _promotionRepository;
        private readonly IMapper _mapper;
        public PromotionService(IRepository<Promotion> promotionRepository, IMapper mapper, IPromotionRespository promotionRespo)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreatePromotionAsync(Promotion promotion)
        {
            try
            {
                promotion.Id = System.Guid.NewGuid().ToString();
                promotion.Active = true;
                promotion.CreatedBy = "admin";
                promotion.CreatedDate = DateTime.Now;
                promotion.UpdatedDate = DateTime.Now;
                await _promotionRepository.AddAsync(promotion);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
