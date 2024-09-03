using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_DataAccessLayer.Models
{
    public class Category
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        //Relationships
        //public List<Product> Products { get; set; }
    }
}
