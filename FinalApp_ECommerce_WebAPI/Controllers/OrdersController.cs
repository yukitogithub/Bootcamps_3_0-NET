using FinalApp_ECommerce_BusinessLayer.DTOs;
using FinalApp_ECommerce_BusinessLayer.Interfaces;
using FinalApp_ECommerce_BusinessLayer.Services;
using FinalApp_ECommerce_DataAccessLayer.Data;
using FinalApp_ECommerce_DataAccessLayer.Models;
using FinalApp_ECommerce_WebAPI.Infrastructure.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalApp_ECommerce_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto orderDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            //TODO: Añadir más validaciones, por ej, que la lista de productos no contenga productos duplicados, que los precios no sean cero o negativos, que la cantidad sea mayor a cero, que el userId sea mayor a cero, etc.
            //TODO: Map CreateOrderDto to OrderDto

            var order = new OrderDto
            {
                UserId = orderDto.UserId,
                OrderItems = orderDto.OrderItems.Select(oi => new OrderItemDto
                {
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                    Price = oi.Price
                }).ToList()
            };

            try
            {
                var succeded = await _orderService.PlaceOrder(order);
                if (succeded) return Ok("Order placed successfully");
                else return BadRequest("Order could not be placed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            //TODO: Implementar paginación en servicio
            var orders = await _orderService.GetOrders();
            return Ok(orders);
        }


    }
}
