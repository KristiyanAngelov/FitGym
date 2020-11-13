namespace FitGym.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    using FitGym.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Any())
            {
                return;
            }

            var users = new List<(string Email, string Password)>
            {
                // 123456 -> hashed password "AQAAAAEAACcQAAAAEIBaDu0WstEaMQy6+oPrUFNAUYh8OcXd56pNJCbG/GcMfjnvwZO0WTWxnRonZUX3hQ=="
                ("admin@test.com", "AQAAAAEAACcQAAAAEIBaDu0WstEaMQy6+oPrUFNAUYh8OcXd56pNJCbG/GcMfjnvwZO0WTWxnRonZUX3hQ=="),
                ("trainer@test.com", "AQAAAAEAACcQAAAAEIBaDu0WstEaMQy6+oPrUFNAUYh8OcXd56pNJCbG/GcMfjnvwZO0WTWxnRonZUX3hQ=="),
                ("client@test.com", "AQAAAAEAACcQAAAAEIBaDu0WstEaMQy6+oPrUFNAUYh8OcXd56pNJCbG/GcMfjnvwZO0WTWxnRonZUX3hQ=="),
            };

            foreach (var user in users)
            {
                await dbContext.Users.AddAsync(new ApplicationUser
                {
                    UserName = user.Email,
                    Email = user.Email,
                    PasswordHash = user.Password,
                });
            }
        }
    }
}
