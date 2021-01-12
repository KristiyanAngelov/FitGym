namespace FitGym.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class WorkoutExercise
    {
        [Required]
        public int WorkoutId { get; set; }

        public virtual Workout Workout { get; set; }

        [Required]
        public string ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; }
    }
}
