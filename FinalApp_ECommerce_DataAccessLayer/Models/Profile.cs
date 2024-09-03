using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_DataAccessLayer.Models
{
    [Owned]
    public class Profile
    {
        //Properties
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
    }
}
