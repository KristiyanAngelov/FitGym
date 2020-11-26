namespace FitGym.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitGym.Common;
    using FitGym.Data.Models;
    using FitGym.Services.Data.Interfaces;
    using FitGym.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UsersController : BaseController
    {
        private readonly IUsersService usersService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UsersController(IUsersService usersService, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.usersService = usersService;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult GetById(string id)
        {
            var viewModel = this.usersService.GetUserById<UserViewModel>(id);
            return this.View(viewModel);
        }

        public IActionResult GetUser(string id)
        {
            return this.View(this.usersService.GetUserById(id));
        }

        public async Task<IActionResult> GetUserRoles(string id)
        {
            var user = this.usersService.GetUserById(id);
            var roles = await this.usersService.GetUserRolesAsync(id);

            var viewModel = new UserAndRolesViewModel
            {
                Email = user.Email,
                Roles = roles,
            };

            return this.View(viewModel);
        }
    }
}
