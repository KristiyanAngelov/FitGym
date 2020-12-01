namespace FitGym.Data.Models
{
    public class WorkoutExercise
    {
        public int WorkoutId { get; set; }

        public virtual Workout Workout { get; set; }

        public string ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; }
    }
}
