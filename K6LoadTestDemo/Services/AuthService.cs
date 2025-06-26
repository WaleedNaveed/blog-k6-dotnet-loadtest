using K6LoadTestDemo.Data;
using K6LoadTestDemo.Interfaces;
using Microsoft.EntityFrameworkCore;
using Login = K6LoadTestDemo.DTOs.Login;

namespace K6LoadTestDemo.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly IJwtService _jwt;

        public AuthService(AppDbContext db, IJwtService jwt)
        {
            _db = db;
            _jwt = jwt;
        }
        public async Task<ServiceResponse<Login.Response>> LoginAsync(Login.Request request)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.Email == request.Username && u.Password == request.Password);

            if (user is null)
                return new ServiceResponse<Login.Response>()
                    { HasError = true, ErrorMessage = "User not found!" };

            var token = _jwt.GenerateToken(user);

            return new ServiceResponse<Login.Response>()
                { HasError = false, Result = new Login.Response() { Token = token } };
        }
    }
}