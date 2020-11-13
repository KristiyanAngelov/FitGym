namespace FitGym.Web.ViewModels.Categories
{
    using FitGym.Data.Models;
    using FitGym.Services.Mapping;
    using System.Collections.Generic;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}