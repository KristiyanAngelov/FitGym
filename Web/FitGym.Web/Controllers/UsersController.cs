namespace FitGym.Web.Controllers
{
    using FitGym.Common;
    using FitGym.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UsersController : BaseController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
    }
}
