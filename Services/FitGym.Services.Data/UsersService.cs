namespace FitGym.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FitGym.Data.Common.Repositories;
    using FitGym.Data.Models;
    using FitGym.Services.Data.Interfaces;
    using FitGym.Services.Mapping;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersService(IDeletableEntityRepository<ApplicationUser> userRepository, UserManager<ApplicationUser> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<T>> GetAllUsersAsync<T>(string trainerId = null)
        {
            return await this.userRepository
                .All()
                .To<T>()
                .ToListAsync();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string id)
        {
            return await this.userRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetUserByIdAsync<T>(string id)
        {
            return await this.userRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstAsync();
        }

        public async Task<List<string>> GetUserRoles(string id)
        {
            var user = await this.userRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);
            var userRoles = await this.userManager.GetRolesAsync(user);

            return userRoles.ToList();
        }
    }
}
