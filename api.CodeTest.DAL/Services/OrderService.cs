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
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IRepository<Order> orderRepository, IMapper mapper, IOrderRepository orderRepo)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            try
            {
                order.Id = System.Guid.NewGuid().ToString();
                order.Active = true;
                order.CreatedBy = "admin";
                order.CreatedDate = DateTime.Now;
                order.UpdatedDate = DateTime.Now;
                await _orderRepository.AddAsync(order);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
