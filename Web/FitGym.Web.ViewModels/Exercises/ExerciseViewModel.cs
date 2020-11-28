namespace FitGym.Web.ViewModels.Exercises
{
    using FitGym.Data.Models;
    using FitGym.Data.Models.Enums;
    using FitGym.Services.Mapping;

    public class ExerciseViewModel : IMapFrom<Exercise>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string VideoUrl { get; set; }

        public Difficulty Difficulty { get; set; }

        public ExerciseType Type { get; set; }
    }
}
