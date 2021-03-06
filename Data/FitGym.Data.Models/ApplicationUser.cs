﻿// ReSharper disable VirtualMemberCallInConstructor
namespace FitGym.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FitGym.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Trainers = new HashSet<ClientTrainer>();
            this.Clients = new HashSet<ClientTrainer>();
            this.TrainerWorkouts = new HashSet<TrainerWorkout>();
            this.ClientWorkouts = new HashSet<ClientWorkout>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        public string ProfilePictureUrl { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<ClientTrainer> Trainers { get; set; }

        public virtual ICollection<ClientTrainer> Clients { get; set; }

        public virtual ICollection<TrainerWorkout> TrainerWorkouts { get; set; }

        public virtual ICollection<ClientWorkout> ClientWorkouts { get; set; }
    }
}
