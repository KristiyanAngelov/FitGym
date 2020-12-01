namespace FitGym.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitGym.Data.Models;

    public interface IUsersService
    {
        public ICollection<ApplicationUser> GetAllUsers();

        public ICollection<T> GetAllUsers<T>();

        public ICollection<T> GetAllDeletedUsers<T>();

        public Task<List<ApplicationUser>> GetAllTrainersAsync();

        public ApplicationUser GetUserById(string id);

        public T GetUserById<T>(string id);

        public Task<List<string>> GetUserRolesAsync(string id);

        public Task DeleteUser(string id);

        public Task HardDeleteUser(string id);

        public Task UndeleteUser(string id);
    }
}
