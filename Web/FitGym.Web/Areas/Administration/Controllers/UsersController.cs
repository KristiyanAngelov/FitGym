namespace FitGym.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FitGym.Services.Data.Interfaces;
    using FitGym.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : AdministrationController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult AllUsers()
        {
            var viewModel = new AllUsersViewModel
            {
                Users = this.usersService.GetAllUsers<UserViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult AllDeletedUsers()
        {
            var viewModel = new AllUsersViewModel
            {
                Users = this.usersService.GetAllDeletedUsers<UserViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> DeleteUser(string userId)
        {
            await this.usersService.DeleteUser(userId);

            return this.RedirectToAction("AllUsers");
        }

        public async Task<IActionResult> HardDeleteUser(string userId)
        {
            await this.usersService.HardDeleteUser(userId);
            return this.RedirectToAction("AllDeletedUsers");
        }

        public async Task<IActionResult> UndeleteUser(string userId)
        {
            await this.usersService.UndeleteUser(userId);

            return this.RedirectToAction("AllDeletedUsers");
        }
    }
}
