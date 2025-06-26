using K6LoadTestDemo.Services;
using GetAllProducts = K6LoadTestDemo.DTOs.GetAllProducts;
using GetProductById = K6LoadTestDemo.DTOs.GetProductById;

namespace K6LoadTestDemo.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetAllProducts.Response>>> GetAllProductsAsync();
        Task<ServiceResponse<GetProductById.Response>> GetProductByIdAsync(GetProductById.Request request);
    }
}