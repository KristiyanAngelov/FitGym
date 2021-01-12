namespace FitGym.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ClientWorkout
    {
        [Required]
        public string ClientId { get; set; }

        public ApplicationUser Client { get; set; }

        [Required]
        public int WorkoutId { get; set; }

        public Workout CWorkout { get; set; }
    }
}
