namespace FitGym.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitGym.Data.Models;

    public interface IUsersService
    {
        public ICollection<T> GetAllUsers<T>(string trainerId = null);

        public ICollection<T> GetAllDeletedUsers<T>(string trainerId = null);

        public Task<List<ApplicationUser>> GetAllTrainersAsync();

        public ApplicationUser GetUserById(string id);

        public T GetUserById<T>(string id);

        public Task<List<string>> GetUserRolesAsync(string id);

        public Task DeleteUser(string id);

        public Task HardDeleteUser(string id);

        public Task UndeleteUser(string id);
    }
}
