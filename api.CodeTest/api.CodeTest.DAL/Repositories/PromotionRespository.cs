using api.CodeTest.DAL.Models;
using api.CodeTest.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.Repositories
{
    public class PromotionRespository : Repository<Promotion>, IPromotionRespository
    {
        public PromotionRespository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
