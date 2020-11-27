namespace FitGym.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using FitGym.Services.Data.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class RolesController : AdministrationController
    {
        private readonly IRolesService rolesService;

        public RolesController(IRolesService rolesService)
        {
            this.rolesService = rolesService;
        }

        public async Task<IActionResult> AddToRole(string userId, string roleName)
        {
            var user = await this.rolesService.AddRoleAsync(userId, roleName);

            return this.Redirect("/Administration/Users/AllUsers");
        }

        public async Task<IActionResult> Remove(string userId, string roleName)
        {
            await this.rolesService.RemoveRoleAsync(userId, roleName);
            return this.Redirect("/Administration/Users/AllUsers");
        }
    }
}
