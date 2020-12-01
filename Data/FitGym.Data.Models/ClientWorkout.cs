namespace FitGym.Data.Models
{
    public class ClientWorkout
    {
        public string ClientId { get; set; }

        public ApplicationUser Client { get; set; }

        public int WorkoutId { get; set; }

        public Workout CWorkout { get; set; }
    }
}
