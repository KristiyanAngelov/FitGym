namespace FitGym.Services.Data
{
    using System;
    using System.Collections;
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
        private readonly RoleManager<ApplicationRole> roleManager;

        public UsersService(IDeletableEntityRepository<ApplicationUser> userRepository, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<List<ApplicationUser>> GetAllTrainersAsync()
        {
            var users = await this.userManager.GetUsersInRoleAsync("Trainer");

            return users.ToList();
        }

        public ICollection<T> GetAllUsers<T>(string trainerId = null)
        {
            return this.userRepository
                .All()
                .To<T>()
                .ToList();
        }

        public ICollection<T> GetAllDeletedUsers<T>(string trainerId = null)
        {
            return this.userRepository
                .AllWithDeleted()
                .Where(x => x.IsDeleted == true)
                .To<T>()
                .ToList();
        }

        public ApplicationUser GetUserById(string id)
        {
            return this.userRepository
                .All()
                .FirstOrDefault(x => x.Id == id);
        }

        public T GetUserById<T>(string id)
        {
            return this.userRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .First();
        }

        public async Task<List<string>> GetUserRolesAsync(string id)
        {
            var user = await this.userRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);
            var userRoles = await this.userManager.GetRolesAsync(user);

            return userRoles.ToList();
        }

        public async Task DeleteUser(string id)
        {
            var user = this.userRepository.All().FirstOrDefault(x => x.Id == id);
            this.userRepository.Delete(user);
            await this.userRepository.SaveChangesAsync();
        }

        public async Task HardDeleteUser(string id)
        {
            var user = this.userRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            //await this.userManager.DeleteAsync(user);
            this.userRepository.HardDelete(user);
            await this.userRepository.SaveChangesAsync();
        }

        public async Task UndeleteUser(string id)
        {
            var user = this.userRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);
            this.userRepository.Undelete(user);
            await this.userRepository.SaveChangesAsync();
        }
    }
}
