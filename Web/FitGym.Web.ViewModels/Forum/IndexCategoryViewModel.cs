namespace FitGym.Web.ViewModels.Forum
{
    using FitGym.Data.Models;
    using FitGym.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int PostsCount { get; set; }

        public string Url => $"/f/{this.Name.Replace(' ', '-')}";
    }
}
