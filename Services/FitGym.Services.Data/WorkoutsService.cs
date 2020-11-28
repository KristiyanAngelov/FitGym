namespace FitGym.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FitGym.Data.Common.Repositories;
    using FitGym.Data.Models;
    using FitGym.Services.Data.Interfaces;
    using FitGym.Services.Mapping;
    using Microsoft.AspNetCore.Identity;

    public class WorkoutsService : IWorkoutsService
    {
        private readonly IDeletableEntityRepository<Workout> workoutsRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public WorkoutsService(
            IDeletableEntityRepository<Workout> workoutsRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.workoutsRepository = workoutsRepository;
            this.userManager = userManager;
        }

        public async Task<int> CreateAsync(string name, DateTime dateAndTime, bool privateTraining, ICollection<string> trainersIds)
        {
            var workout = new Workout
            {
                Name = name,
                DateAndTime = dateAndTime,
                PrivateTraining = privateTraining,
            };
            foreach (var trainerId in trainersIds)
            {
                var trainer = await this.userManager.FindByIdAsync(trainerId);
                workout.Trainers.Add(trainer);
            }

            //await this.workoutsRepository.AddAsync(workout);
            //await this.workoutsRepository.SaveChangesAsync();
            return workout.Id;
        }

        public ICollection<T> GetAllGroupWorkouts<T>()
        {
            return this.workoutsRepository
                .All()
                .Where(x => x.PrivateTraining == false)
                .To<T>()
                .ToList();
        }
    }
}
