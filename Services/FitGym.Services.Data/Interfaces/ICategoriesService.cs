namespace FitGym.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        IEnumerable<T> GetAllPosts<T>(int id);

        T GetByName<T>(string name);

        Task<int> CreateAsync(string name, string title, string description, string imageUrl);
    }
}
