namespace FitGym.Web.Controllers
{
    using System.Threading.Tasks;

    using FitGym.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class TrainersController : BaseController
    {
        private readonly IUsersService usersService;

        public TrainersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var trainers = await this.usersService.GetAllTrainersAsync();
            return this.View(trainers);
        }
    }
}
