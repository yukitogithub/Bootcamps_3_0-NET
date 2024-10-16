using FinalApp_ECommerce_BusinessLayer.Interfaces;
using FinalApp_ECommerce_DataAccessLayer.Data;
using FinalApp_ECommerce_DataAccessLayer.Models;
using FinalApp_ECommerce_WebAPI.Infrastructure.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalApp_ECommerce_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        [Authorize]
        [Route("page/{pageNumber}/size/{pageSize}")]
        public async Task<IActionResult> Get([FromQuery] string? searchTerm, [FromQuery] string? sortBy, [FromQuery] string? sortOrder, int pageNumber = 1, int pageSize = 10)
        {
            var products = await _productService.GetAllProductsAsync(searchTerm, sortBy, sortOrder, pageNumber, pageSize);

            return Ok(products);
        }

        // GET: api/Products/5
        [Authorize]
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Post([FromBody] AddProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = productDto.Name,
                    Description = productDto.Description,
                    Price = productDto.Price,
                    CategoryId = productDto.CategoryId
                };

                var succeeded = await _productService.AddProduct(product);
                if (succeeded) return CreatedAtAction("GetProduct", new { id = product.Id }, product); //post redirect get
                else return BadRequest("Product could not be added");
            }
            
            return BadRequest(ModelState);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                if (id != product.Id)
                    return BadRequest("Id mismatch");

                try
                {
                    var succeeded = await _productService.UpdateProduct(id, product);
                    if (succeeded) return NoContent();
                    else return BadRequest("Product could not be updated");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(id))
                        return NotFound("Product not found");
                    else
                        throw;
                }
            }

            return BadRequest(ModelState);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            var succeeded = await _productService.DeleteProduct(id);
            if (!succeeded) return BadRequest("Product could not be deleted");
            else return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _productService.GetProductByIdAsync(id) != null;
        }
    }
}
