namespace FitGym.Web.Controllers
{
    using System.Threading.Tasks;

    using FitGym.Common;
    using FitGym.Services.Data.Interfaces;
    using FitGym.Web.ViewModels.Exercises;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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

        [Authorize(Roles = GlobalConstants.AdminAndTrainerRolesRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdminAndTrainerRolesRoleName)]
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
