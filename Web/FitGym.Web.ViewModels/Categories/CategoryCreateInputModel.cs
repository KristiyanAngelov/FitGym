namespace FitGym.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using FitGym.Data.Models;
    using FitGym.Services.Mapping;

    public class CategoryCreateInputModel : IMapTo<Category>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
