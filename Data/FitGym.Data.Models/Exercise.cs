namespace FitGym.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FitGym.Data.Common.Models;
    using FitGym.Data.Models.Enums;

    public class Exercise : BaseDeletableModel<string>
    {
        public Exercise()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Workouts = new HashSet<WorkoutExercise>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        public Difficulty Difficulty { get; set; }

        public ExerciseType Type { get; set; }

        public virtual ICollection<WorkoutExercise> Workouts { get; set; }
    }
}
