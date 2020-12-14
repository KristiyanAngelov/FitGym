namespace FitGym.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using FitGym.Data.Common.Repositories;
    using FitGym.Data.Models;
    using FitGym.Services.Data.Contracts;
    using FitGym.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Identity;

    public class RolesService : IRolesService
    {
        private readonly IUsersService usersService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<ApplicationRole> rolesRepository;

        public RolesService(
            IUsersService usersService,
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<ApplicationRole> rolesRepository)
        {
            this.usersService = usersService;
            this.userManager = userManager;
            this.rolesRepository = rolesRepository;
        }

        public async Task<ApplicationUser> AddRoleAsync(string userId, string roleName)
        {
            var user = this.usersService.GetUserById(userId);
            await this.userManager.AddToRoleAsync(user, roleName);

            return user;
        }

        public async Task<ApplicationUser> RemoveRoleAsync(string userId, string roleName)
        {
            var user = this.usersService.GetUserById(userId);
            await this.userManager.RemoveFromRoleAsync(user, roleName);

            return user;
        }
    }
}
