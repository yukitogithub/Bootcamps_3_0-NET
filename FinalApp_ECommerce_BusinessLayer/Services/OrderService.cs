using FinalApp_ECommerce_BusinessLayer.DTOs;
using FinalApp_ECommerce_BusinessLayer.Interfaces;
using FinalApp_ECommerce_DataAccessLayer.Data;
using FinalApp_ECommerce_DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_BusinessLayer.Services
{
    public class OrderService: IOrderService
    {
        private readonly ECommerceDbContext _context;
        private readonly IProductService _productService;
        public OrderService(ECommerceDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        public async Task<bool> PlaceOrder(OrderDto orderDto)
        {
            //TODO: Añadir más validaciones, por ej, que el usuario exista, que los precios sean correctos, etc.

            //Evitar el posible error en la carga de la tabla intermedia
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                foreach (var item in orderDto.OrderItems)
                {
                    var product = await _productService.GetProductByIdAsync(item.ProductId);

                    if (product == null)
                    {
                        return false;
                    }

                    if (product.Stock < item.Quantity)
                        return false;
                    else if (product.Stock >= item.Quantity)
                    {
                        product.Stock -= item.Quantity;
                        await _productService.UpdateProduct(product.Id, product);
                    }
                }

                var order = new Order
                {
                    UserId = orderDto.UserId,
                    OrderDate = DateTime.Now,
                    OrderNumber = Guid.NewGuid().ToString(),
                    TotalAmount = orderDto.OrderItems.Sum(oi => oi.Quantity * oi.Price)
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                foreach (var item in orderDto.OrderItems)
                {
                    var orderItem = new OrderItem
                    {
                        OrderId = order.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = item.Price
                    };

                    _context.OrderItems.Add(orderItem);
                }

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            //Para traer los datos relacionados usamos Include, en este caso traemos el usuario y los productos de cada orden, así como la categoría de cada producto
            var orders = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ThenInclude(p => p.Category)
                .ToListAsync();

            return orders;
        }
    }
}
