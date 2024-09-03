using FinalApp_ECommerce_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_BusinessLayer.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);
    }
}
