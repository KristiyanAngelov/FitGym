namespace FitGym.Web.Areas.Administration.Controllers
{
    using FitGym.Data.Models;
    using FitGym.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class DashboardController:AdministrationController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public DashboardController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> ListUsers()
        {
            var users = await this.userManager.GetUsersInRoleAsync("Trainer");
            return this.View(users);
        }
    }
}
