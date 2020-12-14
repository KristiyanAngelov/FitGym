namespace FitGym.Web.ViewModels.Workouts
{
    using System.Collections.Generic;

    using AutoMapper;
    using FitGym.Data.Models;
    using FitGym.Services.Mapping;

    public class MyWorkoutsViewModel /*: IMapFrom<ApplicationUser>, IHaveCustomMappings*/
    {
        public ICollection<Workout> MyClientWorkouts { get; set; }

        public ICollection<Workout> MyTrainerWorkouts { get; set; }

        // public void CreateMappings(IProfileExpression configuration)
        // {
        //    configuration.CreateMap<ApplicationUser, MyWorkoutsViewModel>()
        //        .ForMember(
        //        m => m.MyClientWorkouts,
        //        opt => opt.MapFrom(x => x.ClientWorkouts))
        //        .ForMember(
        //        m => m.MyTrainerWorkouts,
        //        opt => opt.MapFrom(x => x.TrainerWorkouts));
        // }
    }
}
