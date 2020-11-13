namespace FitGym.Web.ViewModels.Posts
{
    using FitGym.Data.Models;
    using FitGym.Services.Mapping;

    public class CategoryDropDownViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
