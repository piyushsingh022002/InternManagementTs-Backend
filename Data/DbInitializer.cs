using Backend.Models;
using Microsoft.AspNetCore.Identity;

namespace Backend.Data
{
    public static class DbInitializer
    {
        public static void SeedUsers(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (!context.Users.Any())
            {
                var hasher = new PasswordHasher<User>();

                var hrUser = new User
                {
                    Email = "hr@example.com",
                    PasswordHash = "", // Will be set below
                    Role = "HR"
                };
                hrUser.PasswordHash = hasher.HashPassword(hrUser, "hr@123");

                context.Users.Add(hrUser);
                context.SaveChanges();
            }
        }
    }
}
