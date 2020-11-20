namespace FitGym.Web.ViewModels.Users
{
    using System.Collections.Generic;

    using FitGym.Data.Models;
    using FitGym.Services.Mapping;
    using Microsoft.AspNetCore.Identity;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
