using api.CodeTest.DAL.Models;
using api.CodeTest.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
