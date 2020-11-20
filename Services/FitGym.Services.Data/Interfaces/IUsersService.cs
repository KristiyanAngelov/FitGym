namespace FitGym.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitGym.Data.Models;

    public interface IUsersService
    {
        public Task<IEnumerable<T>> GetAllUsersAsync<T>(string trainerId = null);

        public Task<List<ApplicationUser>> GetAllTrainersAsync();

        public Task<ApplicationUser> GetUserByIdAsync(string id);

        public Task<T> GetUserByIdAsync<T>(string id);

        public Task<List<string>> GetUserRoles(string id);
    }
}
