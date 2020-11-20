namespace FitGym.Web.Areas.Administration.Controllers
{
    using FitGym.Common;
    using FitGym.Data.Models;
    using FitGym.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
        public AdministrationController()
        {
        }
    }
}
