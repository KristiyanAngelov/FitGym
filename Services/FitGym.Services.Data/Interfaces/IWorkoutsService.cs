namespace FitGym.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitGym.Data.Models;

    public interface IWorkoutsService
    {
        public ICollection<T> GetAllGroupWorkouts<T>();

        public Task<int> CreateAsync(string name, DateTime startTime, DateTime endTime, bool privateTraining, string notes, ICollection<string> trainersIds, ICollection<string> exercisesIds, ICollection<string> clientsIds);

        public Task<ICollection<Workout>> GetUserWorkoutsAsClientAsync(string userId);

        public Task<ICollection<Workout>> GetUserWorkoutsAsTrainerAsync(string userId);
    }
}
