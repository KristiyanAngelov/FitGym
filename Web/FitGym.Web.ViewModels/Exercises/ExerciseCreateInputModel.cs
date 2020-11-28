namespace FitGym.Web.ViewModels.Exercises
{
    using System.ComponentModel.DataAnnotations;

    using FitGym.Data.Models.Enums;

    public class ExerciseCreateInputModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Video File is Required.")]
        public string VideoUrl { get; set; }

        [Required]
        public Difficulty Difficulty { get; set; }

        [Required]
        public ExerciseType Type { get; set; }
    }
}
