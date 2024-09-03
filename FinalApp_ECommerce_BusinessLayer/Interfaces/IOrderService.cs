using FinalApp_ECommerce_BusinessLayer.DTOs;
using FinalApp_ECommerce_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_BusinessLayer.Interfaces
{
    public interface IOrderService
    {
        Task<bool> PlaceOrder(OrderDto orderDto);
        Task<IEnumerable<Order>> GetOrders();
    }
}
