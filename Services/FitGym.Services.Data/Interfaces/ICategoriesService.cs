namespace FitGym.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        IEnumerable<T> GetAllPosts<T>(int id);

        T GetByName<T>(string name);
    }
}
