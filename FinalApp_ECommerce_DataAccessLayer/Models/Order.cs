using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_DataAccessLayer.Models
{
    public class Order
    {
        //Properties
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public decimal TotalAmount { get; set; }
        //Relationships
        public int UserId { get; set; }
        public User User { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
