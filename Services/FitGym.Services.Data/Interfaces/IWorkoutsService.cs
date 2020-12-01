namespace FitGym.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWorkoutsService
    {
        public ICollection<T> GetAllGroupWorkouts<T>();

        Task<int> CreateAsync(string name, DateTime startTime, DateTime endTime, bool privateTraining, string notes, ICollection<string> trainersIds, ICollection<string> exercisesIds);
    }
}
