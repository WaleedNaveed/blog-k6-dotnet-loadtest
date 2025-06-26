using K6LoadTestDemo.Models;

namespace K6LoadTestDemo.Data
{
    public static class Seeder
    {
        public static void Seed(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            db.Users.Add(new User
            {
                Email = "admin@example.com",
                Password = "123456"
            });

            db.Products.AddRange(
                new Product { Name = "Keyboard", Price = 2500 },
                new Product { Name = "Mouse", Price = 1200 },
                new Product { Name = "Monitor", Price = 34000 }
            );

            db.SaveChanges();
        }
    }
}