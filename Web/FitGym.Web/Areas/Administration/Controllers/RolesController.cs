using FitGym.Data.Models;
using FitGym.Services.Data.Contracts;
using FitGym.Services.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitGym.Web.Areas.Administration.Controllers
{
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
