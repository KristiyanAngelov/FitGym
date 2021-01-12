namespace FitGym.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TrainerWorkout
    {
        [Required]
        public string TrainerId { get; set; }

        public ApplicationUser Trainer { get; set; }

        [Required]
        public int WorkoutId { get; set; }

        public Workout TWorkout { get; set; }
    }
}
