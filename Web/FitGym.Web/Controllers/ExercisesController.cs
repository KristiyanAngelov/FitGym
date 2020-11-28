using FitGym.Services.Data.Interfaces;
using FitGym.Web.ViewModels.Exercises;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitGym.Web.Controllers
{
    public class ExercisesController : BaseController
    {
        private readonly IExercisesService exercisesService;

        public ExercisesController(IExercisesService exercisesService)
        {
            this.exercisesService = exercisesService;
        }

        public IActionResult All()
        {
            var viewModel = new AllExercisesViewModel
            {
                Exercises = this.exercisesService.GetAllExercises<ExerciseViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExerciseCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var exerciseId = await this.exercisesService.CreateAsync(input);

            return this.RedirectToAction("All");
        }
    }
}
