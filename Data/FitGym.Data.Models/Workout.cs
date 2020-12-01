namespace FitGym.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FitGym.Data.Common.Models;

    public class Workout : BaseDeletableModel<int>
    {
        public Workout()
        {
            this.Trainers = new HashSet<TrainerWorkout>();
            this.Clients = new HashSet<ClientWorkout>();
            this.Exercises = new HashSet<WorkoutExercise>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }

        [Required]
        public bool PrivateTraining { get; set; }

        public virtual ICollection<TrainerWorkout> Trainers { get; set; }

        public virtual ICollection<ClientWorkout> Clients { get; set; }

        public virtual ICollection<WorkoutExercise> Exercises { get; set; }
    }
}
