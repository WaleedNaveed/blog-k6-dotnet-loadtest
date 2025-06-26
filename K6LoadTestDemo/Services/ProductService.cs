using K6LoadTestDemo.Data;
using K6LoadTestDemo.Interfaces;
using Microsoft.EntityFrameworkCore;
using GetAllProducts = K6LoadTestDemo.DTOs.GetAllProducts;
using GetProductById = K6LoadTestDemo.DTOs.GetProductById;

namespace K6LoadTestDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _db;

        public ProductService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ServiceResponse<List<GetAllProducts.Response>>> GetAllProductsAsync()
        {
            var response = new ServiceResponse<List<GetAllProducts.Response>>();

            var products = await _db.Products.ToListAsync();

            response.Result = products.Select(p => new GetAllProducts.Response
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();

            return response;
        }

        public async Task<ServiceResponse<GetProductById.Response>> GetProductByIdAsync(GetProductById.Request request)
        {
            var response = new ServiceResponse<GetProductById.Response>();

            var product = await _db.Products.FindAsync(request.Id);

            if (product is null)
            {
                response.HasError = true;
                response.ErrorMessage = $"Product with ID {request.Id} not found.";
                return response;
            }

            response.Result = new GetProductById.Response
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            return response;
        }
    }
}