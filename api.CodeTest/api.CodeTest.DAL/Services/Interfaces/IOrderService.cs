using api.CodeTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api.CodeTest.DAL.Services.Interfaces
{
    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(Order order);
    }
}
