using FinalApp_ECommerce_BusinessLayer.DTOs;
using FinalApp_ECommerce_BusinessLayer.Interfaces;
using FinalApp_ECommerce_DataAccessLayer.Interfaces;
using FinalApp_ECommerce_DataAccessLayer.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp_ECommerce_BusinessLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PaginationResponseDto<Product>> GetAllProductsAsync(string? searchTerm, string? sortBy, string? sortOrder, int pageNumber, int pageSize)
        {
            IEnumerable<Product>? products = null;

            //Filtrado y/o Búsqueda
            if (searchTerm == null || searchTerm.Equals(string.Empty))
                products = await _productRepository.GetAllAsync();
            else
                products = await _productRepository.SearchProductsAsync(searchTerm);

            //Ordenamiento
            switch (sortBy)
            {
                case "name":
                    products = sortOrder == "asc" ? products.OrderBy(p => p.Name) : products.OrderByDescending(p => p.Name);
                    break;
                case "price":
                    products = sortOrder == "asc" ? products.OrderBy(p => p.Price) : products.OrderByDescending(p => p.Price);
                    break;
                case "stock":
                    products = sortOrder == "asc" ? products.OrderBy(p => p.Stock) : products.OrderByDescending(p => p.Stock);
                    break;
                case "category":
                    products = sortOrder == "asc" ? products.OrderBy(p => p.Category.Name) : products.OrderByDescending(p => p.Category.Name);
                    break;
                case "description":
                    products = sortOrder == "asc" ? products.OrderBy(p => p.Description) : products.OrderByDescending(p => p.Description);
                    break;
                default:
                    break;
            }

            //Paginación
            var totalItems = products.Count();
            var paginatedProducts = products
                .Skip(pageSize * (pageNumber - 1)) //Saltear la x cantidad de productos de la lista
                .Take(pageSize); //Tomar la x cantidad de productos de la lista

            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            var paginationMetadata = new PaginationMetadata 
            { 
                CurrentPage = pageNumber, 
                PageSize = pageSize, 
                TotalItems = totalItems, 
                TotalPages = totalPages,
                HasNext = pageNumber < totalPages,
                NextPageUrl = pageNumber < totalPages ? $"/api/products/page/{pageNumber + 1}/size/{pageSize}" : null,
                HasPrevious = pageNumber > 1,
                PreviousPageUrl = pageNumber > 1 ? $"/api/products/page/{pageNumber - 1}/size/{pageSize}" : null
            };

            var response = new PaginationResponseDto<Product>
            {
                Data = paginatedProducts.ToList(),
                Pagination = paginationMetadata
            };

            return response;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _productRepository.GetProductsByCategoryAsync(categoryId);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddProduct(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                await _productRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProduct(int id, Product product)
        {
            try
            {
                await _productRepository.UpdateAsync(product);
                await _productRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                await _productRepository.DeleteAsync(await _productRepository.GetByIdAsync(id));
                await _productRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
