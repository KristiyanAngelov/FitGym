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

        public async Task<int> CreateAsync(
            string name,
            DateTime startTime,
            DateTime endTime,
            bool privateTraining,
            string notes,
            ICollection<string> trainersIds,
            ICollection<string> exercisesIds,
            ICollection<string> clientsIds)
        {
            var workout = new Workout
            {
                Name = name,
                StartTime = startTime,
                EndTime = endTime,
                PrivateTraining = privateTraining,
                Notes = notes,
            };

            await this.workoutsRepository.AddAsync(workout);
            await this.workoutsRepository.SaveChangesAsync();
            foreach (var trainerId in trainersIds)
            {
                var trainer = await this.userManager.FindByIdAsync(trainerId);
                var tworkout = new TrainerWorkout
                {
                    Trainer = trainer,
                    TrainerId = trainerId,
                    TWorkout = workout,
                    WorkoutId = workout.Id,
                };
                workout.Trainers.Add(tworkout);
                trainer.TrainerWorkouts.Add(tworkout);
            }

            foreach (var exerciseId in exercisesIds)
            {
                var exercise = this.exercisesService.FindByID(exerciseId);
                var we = new WorkoutExercise
                {
                    Exercise = exercise,
                    ExerciseId = exercise.Id,
                    Workout = workout,
                    WorkoutId = workout.Id,
                };
                workout.Exercises.Add(we);
                exercise.Workouts.Add(we);
            }

            foreach (var clientId in clientsIds)
            {
                var client = await this.userManager.FindByIdAsync(clientId);
                var cworkout = new ClientWorkout
                {
                    Client = client,
                    ClientId = clientId,
                    CWorkout = workout,
                    WorkoutId = workout.Id,
                };
                workout.Clients.Add(cworkout);
                client.ClientWorkouts.Add(cworkout);
            }

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

        public async Task<ICollection<Workout>> GetUserWorkoutsAsClientAsync(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var result = this.workoutsRepository.All().Where(x => x.Clients.Contains(new ClientWorkout
            {
                Client = user,
                ClientId = user.Id,
                CWorkout = x,
                WorkoutId = x.Id,
            }));
            return result.ToList();
        }

        public async Task<ICollection<Workout>> GetUserWorkoutsAsTrainerAsync(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var result = this.workoutsRepository.All().Where(x => x.Trainers.Contains(new TrainerWorkout
            {
                Trainer = user,
                TrainerId = user.Id,
                TWorkout = x,
                WorkoutId = x.Id,
            }));
            return result.ToList();
        }
    }
}
