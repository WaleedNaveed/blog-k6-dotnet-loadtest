using K6LoadTestDemo.Services;
using Login = K6LoadTestDemo.DTOs.Login;

namespace K6LoadTestDemo.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<Login.Response>> LoginAsync(Login.Request request);
    }
}