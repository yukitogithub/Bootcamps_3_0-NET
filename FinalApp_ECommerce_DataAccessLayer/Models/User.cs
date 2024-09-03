using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_DataAccessLayer.Models
{
    public class User: IdentityUser<int>
    {
        //Properties
        public string Name { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }

        public Profile Profile { get; set; }
    }
}
