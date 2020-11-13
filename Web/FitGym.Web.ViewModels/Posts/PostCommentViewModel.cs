namespace FitGym.Web.ViewModels.Posts
{
    using System;

    using FitGym.Data.Models;
    using FitGym.Services.Mapping;

    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }
    }
}
