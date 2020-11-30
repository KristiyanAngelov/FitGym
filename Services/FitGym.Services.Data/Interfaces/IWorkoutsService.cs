namespace FitGym.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWorkoutsService
    {
        public ICollection<T> GetAllGroupWorkouts<T>();

        Task<int> CreateAsync(string name, DateTime dateAndTime, bool privateTraining, ICollection<string> trainersIds);
    }
}
