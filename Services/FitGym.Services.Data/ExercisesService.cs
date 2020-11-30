namespace FitGym.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FitGym.Data.Common.Repositories;
    using FitGym.Data.Models;
    using FitGym.Services.Data.Interfaces;
    using FitGym.Services.Mapping;
    using FitGym.Web.ViewModels.Exercises;

    public class ExercisesService : IExercisesService
    {
        private readonly IDeletableEntityRepository<Exercise> exerciseRepository;

        public ExercisesService(IDeletableEntityRepository<Exercise> exerciseRepository)
        {
            this.exerciseRepository = exerciseRepository;
        }

        public async Task<string> CreateAsync(ExerciseCreateInputModel input)
        {
            var exercise = new Exercise
            {
                Name = input.Name,
                VideoUrl = input.VideoUrl,
                Difficulty = input.Difficulty,
                Type = input.Type,
            };

            await this.exerciseRepository.AddAsync(exercise);
            await this.exerciseRepository.SaveChangesAsync();

            return exercise.Id;
        }

        public Exercise FindByID(string exerciseId)
        {
            return this.exerciseRepository
                .All()
                .Where(x => x.Id == exerciseId)
                .FirstOrDefault();
        }

        public ICollection<T> GetAllExercises<T>()
        {
            return this.exerciseRepository
                .All()
                .To<T>()
                .ToList();
        }

        public ICollection<Exercise> GetAllExercises()
        {
            return this.exerciseRepository
                .All()
                .ToList();
        }

    }
}