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
            this.Trainers = new HashSet<ApplicationUser>();
            this.Clients = new HashSet<ApplicationUser>();
            this.Exercises = new HashSet<Exercise>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        [Required]
        public bool PrivateTraining { get; set; }

        public virtual ICollection<ApplicationUser> Trainers { get; set; }

        public virtual ICollection<ApplicationUser> Clients { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
