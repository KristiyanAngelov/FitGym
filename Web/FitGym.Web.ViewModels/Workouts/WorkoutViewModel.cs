namespace FitGym.Web.ViewModels.Workouts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using FitGym.Data.Models;
    using FitGym.Services.Mapping;

    public class WorkoutViewModel : IMapFrom<Workout>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public ICollection<string> TrainersNames { get; set; }

        public int ClientsCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Workout, WorkoutViewModel>()
                .ForMember(
                m => m.TrainersNames,
                opt => opt.MapFrom(x => x.Trainers.Select(x => x.Trainer.FirstName + " " + x.Trainer.LastName)));
        }
    }
}
