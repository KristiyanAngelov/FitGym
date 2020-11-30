﻿namespace FitGym.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitGym.Web.ViewModels.Exercises;

    public interface IExercisesService
    {
        Task<string> CreateAsync(ExerciseCreateInputModel input);

        ICollection<T> GetAllExercises<T>();
    }
}
