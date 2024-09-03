using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_DataAccessLayer.Models
{
    public class Product
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        //Usamos data annotations para validar la longitud del campo
        [Length(0,250)]
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int Stock { get; set; }

        //Relationships
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
