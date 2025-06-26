using K6LoadTestDemo.Models;

namespace K6LoadTestDemo.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}