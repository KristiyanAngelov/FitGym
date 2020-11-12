﻿namespace FitGym.Web.Controllers
{
    using System.Diagnostics;

    using FitGym.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Trainers()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Forum()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
