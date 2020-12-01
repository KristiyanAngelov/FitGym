namespace FitGym.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FitGym.Common;
    using FitGym.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class RolesToUsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedRoleAsync(userManager, GlobalConstants.AdministratorRoleName, "admin@test.com");
            await SeedRoleAsync(userManager, GlobalConstants.TrainerRoleName, "admin@test.com");
            await SeedRoleAsync(userManager, GlobalConstants.TrainerRoleName, "trainer@test.com");
            await SeedRoleAsync(userManager, GlobalConstants.ClientRoleName, "client@test.com");
        }

        private static async Task SeedRoleAsync(UserManager<ApplicationUser> userManager, string roleName, string userEmail)
        {
            var user = await userManager.Users.FirstAsync(x => x.Email == userEmail);
            if (user.Roles.Any() == false)
            {
                await userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}
