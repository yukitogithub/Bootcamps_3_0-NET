using FinalApp_ECommerce_BusinessLayer.DTOs;
using FinalApp_ECommerce_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_BusinessLayer.Interfaces
{
    public interface IProductService
    {
        Task<PaginationResponseDto<Product>> GetAllProductsAsync(string? searchTerm, string? sortBy, string? sortOrder, int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<Product> GetProductByIdAsync(int id);
        Task<bool> AddProduct(Product product);
        Task<bool> UpdateProduct(int id, Product product);
        Task<bool> DeleteProduct(int id);
    }
}
