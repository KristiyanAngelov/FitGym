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

            var users = new List<(string Email, string Password, string FirstName, string LastName, string ProfilePicture)>
            {
                // 123456 -> hashed password "AQAAAAEAACcQAAAAEIBaDu0WstEaMQy6+oPrUFNAUYh8OcXd56pNJCbG/GcMfjnvwZO0WTWxnRonZUX3hQ=="
                ("admin@test.com", "AQAAAAEAACcQAAAAEIBaDu0WstEaMQy6+oPrUFNAUYh8OcXd56pNJCbG/GcMfjnvwZO0WTWxnRonZUX3hQ==", "Kristiyan", "Angelov", "https://cdn.webeyo.com/c/8/7/7/information-about-the-egyptian-hero-big-ramy-bodybuilder/information-about-the-egyptian-hero-big-ramy-bodybuilder-b.jpg"),
                ("trainer@test.com", "AQAAAAEAACcQAAAAEIBaDu0WstEaMQy6+oPrUFNAUYh8OcXd56pNJCbG/GcMfjnvwZO0WTWxnRonZUX3hQ==", "Test", "Trainer", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/portrait-of-a-trainer-in-gym-royalty-free-image-1584723855.jpg"),
                ("client@test.com", "AQAAAAEAACcQAAAAEIBaDu0WstEaMQy6+oPrUFNAUYh8OcXd56pNJCbG/GcMfjnvwZO0WTWxnRonZUX3hQ==", "Test", "Client", "https://tonygentilcore.com/wp-content/uploads/2018/07/Skinny-guy.jpg"),
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
