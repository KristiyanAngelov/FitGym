namespace FitGym.Web.ViewModels.Workouts
{
    using System;
    using System.Collections.Generic;

    using FitGym.Data.Models;
    using FitGym.Services.Mapping;

    public class WorkoutViewModel : IMapFrom<Workout>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateAndTime { get; set; }

        //public ICollection<string> Trainers { get; set; }

        public int ClientsCount { get; set; }

        //TODO Implement other properties than controller->view
    }
}
