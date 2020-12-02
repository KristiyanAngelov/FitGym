namespace FitGym.Web.Controllers
{
    using FitGym.Common;
    using FitGym.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UsersController : BaseController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult GetUserById()
        {
            return this.View(this.usersService.GetUserById("82337fc0-f024-473f-a621-5f8a282ee23f"));
        }
    }
}
