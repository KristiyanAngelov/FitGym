namespace FitGym.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using FitGym.Data.Models;

    public interface IRolesService
    {
        public Task<ApplicationUser> AddRoleAsync(string userId, string roleName);

        public Task<ApplicationUser> RemoveRoleAsync(string userId, string roleName);
    }
}
