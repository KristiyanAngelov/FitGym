namespace FitGym.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FitGym.Data.Models;
    using FitGym.Services.Data.Interfaces;
    using FitGym.Web.ViewModels.Roles;
    using FitGym.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> AllUsers()
        {
            var viewModel = new AllUsersViewModel
            {
                Users = await this.usersService.GetAllUsersAsync<UserViewModel>(),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var viewModel = await this.usersService.GetUserByIdAsync<UserViewModel>(id);
            return this.View(viewModel);
        }

        public async Task<IActionResult> GetUser(string id)
        {
            return this.View(await this.usersService.GetUserByIdAsync(id));
        }

        public async Task<IActionResult> GetUserRoles(string id)
        {
            var testUser = await this.usersService.GetUserByIdAsync(id);
            var roles = await this.usersService.GetUserRoles(id);

            var viewModel = new UserAndRolesViewModel
            {
                Email = testUser.Email,
                Roles = roles,
            };

            return this.View(viewModel);
        }
    }
}
