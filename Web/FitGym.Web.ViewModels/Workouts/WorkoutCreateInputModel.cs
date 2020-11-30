namespace FitGym.Web.ViewModels.Workouts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FitGym.Data.Models;
    using FitGym.Services.Mapping;

    public class WorkoutCreateInputModel : IMapTo<Workout>
    {
        public WorkoutCreateInputModel()
        {
            this.TrainersIds = new HashSet<string>();
            //this.Exercises = new HashSet<Exercise>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        [Required]
        public bool PrivateTraining { get; set; }

        public ICollection<string> TrainersIds { get; set; }

        //public ICollection<Exercise> Exercises { get; set; }
    }
}
