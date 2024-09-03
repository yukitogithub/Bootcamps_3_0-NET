using FinalApp_ECommerce_DataAccessLayer.Data;
using FinalApp_ECommerce_DataAccessLayer.Interfaces;
using FinalApp_ECommerce_DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_DataAccessLayer.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        {
            return await _context.Products.Where(
                p => 
                    p.Name.Contains(searchTerm ?? "", StringComparison.OrdinalIgnoreCase)
                    ||
                    (p.Description != null && p.Description.Contains(searchTerm ?? "", StringComparison.OrdinalIgnoreCase))
                ).ToListAsync();
        }
    }
}
