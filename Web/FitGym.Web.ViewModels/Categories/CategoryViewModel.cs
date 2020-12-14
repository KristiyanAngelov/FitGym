namespace FitGym.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using FitGym.Data.Models;
    using FitGym.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
