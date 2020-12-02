namespace FitGym.Web.Controllers
{
    using System.Threading.Tasks;

    using FitGym.Common;
    using FitGym.Data.Models;
    using FitGym.Services.Data.Interfaces;
    using FitGym.Web.ViewModels.Exercises;
    using FitGym.Web.ViewModels.Workouts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class WorkoutsController : BaseController
    {
        private readonly IWorkoutsService workoutsService;
        private readonly UserManager<ApplicationUser> userManager;

        public WorkoutsController(IWorkoutsService workoutsService, UserManager<ApplicationUser> userManager)
        {
            this.workoutsService = workoutsService;
            this.userManager = userManager;
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

        public async Task<IActionResult> MyWorkouts()
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);
            var viewModel = new MyWorkoutsViewModel
            {
                MyClientWorkouts = await this.workoutsService.GetUserWorkoutsAsClientAsync(currentUser.Id),
                MyTrainerWorkouts = await this.workoutsService.GetUserWorkoutsAsTrainerAsync(currentUser.Id),
            };
            return this.View(viewModel);
        }
    }
}

//TODO