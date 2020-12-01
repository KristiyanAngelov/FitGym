namespace FitGym.Data.Models
{
    public class TrainerWorkout
    {
        public string TrainerId { get; set; }

        public ApplicationUser Trainer { get; set; }

        public int WorkoutId { get; set; }

        public Workout TWorkout { get; set; }
    }
}
