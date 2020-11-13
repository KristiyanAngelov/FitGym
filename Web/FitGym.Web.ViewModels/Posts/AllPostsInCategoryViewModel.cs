namespace FitGym.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    public class AllPostsInCategoryViewModel
    {
        public int CategoryId { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
