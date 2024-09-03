using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_DataAccessLayer.Models
{
    public class OrderItem
    {
        //Properties
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        //Relationships
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
    }
}
