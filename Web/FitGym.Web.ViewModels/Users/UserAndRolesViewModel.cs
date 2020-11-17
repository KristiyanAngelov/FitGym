namespace FitGym.Web.ViewModels.Users
{
    using System.Collections.Generic;

    public class UserAndRolesViewModel
    {
        public string Email { get; set; }

        public ICollection<string> Roles { get; set; }
    }
}
