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
        private readonly IExercisesService exercisesService;

        public WorkoutsService(
            IDeletableEntityRepository<Workout> workoutsRepository,
            UserManager<ApplicationUser> userManager,
            IExercisesService exercisesService)
        {
            this.workoutsRepository = workoutsRepository;
            this.userManager = userManager;
            this.exercisesService = exercisesService;
        }

        public async Task<int> CreateAsync(string name, DateTime dateAndTime, bool privateTraining, ICollection<string> trainersIds, ICollection<string> exercisesIds)
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

            foreach (var exerciseId in exercisesIds)
            {
                var exercise = this.exercisesService.FindByID(exerciseId);
                workout.Exercises.Add(exercise);
            }

            await this.workoutsRepository.AddAsync(workout);
            await this.workoutsRepository.SaveChangesAsync();
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
