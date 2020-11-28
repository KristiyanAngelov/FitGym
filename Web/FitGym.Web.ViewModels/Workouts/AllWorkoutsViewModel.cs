namespace FitGym.Web.ViewModels.Workouts
{
    using System.Collections.Generic;

    public class AllWorkoutsViewModel
    {
        public IEnumerable<WorkoutViewModel> Workouts { get; set; }
    }
}
