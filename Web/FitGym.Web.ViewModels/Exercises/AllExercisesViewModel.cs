namespace FitGym.Web.ViewModels.Exercises
{
    using System.Collections.Generic;

    public class AllExercisesViewModel
    {
        public ICollection<ExerciseViewModel> Exercises { get; set; }
    }
}
