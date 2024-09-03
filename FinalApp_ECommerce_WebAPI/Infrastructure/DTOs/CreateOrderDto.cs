namespace FinalApp_ECommerce_WebAPI.Infrastructure.DTOs
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public List<CreateOrderItemDto> OrderItems { get; set; }
    }

    public class CreateOrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
