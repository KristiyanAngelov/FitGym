namespace FitGym.Web.Controllers
{
    using System.Threading.Tasks;

    using FitGym.Common;
    using FitGym.Services.Data.Interfaces;
    using FitGym.Web.ViewModels.Exercises;
    using FitGym.Web.ViewModels.Workouts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class WorkoutsController : BaseController
    {
        private readonly IWorkoutsService workoutsService;

        public WorkoutsController(IWorkoutsService workoutsService)
        {
            this.workoutsService = workoutsService;
        }

        public IActionResult AllGroupWorkouts()
        {
            var viewModel = new AllWorkoutsViewModel
            {
                Workouts = this.workoutsService.GetAllGroupWorkouts<WorkoutViewModel>(),
            };

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.TrainerRoleName)]
        public IActionResult CreateWorkout()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.TrainerRoleName)]
        [HttpPost]
        public async Task<IActionResult> CreateWorkout(WorkoutCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var workoutId = await this.workoutsService.CreateAsync(input.Name, input.StartTime, input.EndTime, input.PrivateTraining, input.Notes, input.TrainersIds, input.ExercisesIds, input.ClientsIds);
            this.TempData["InfoMessage"] = "The workout is created!";
            return this.RedirectToAction("AllGroupWorkouts");
        }
    }
}
