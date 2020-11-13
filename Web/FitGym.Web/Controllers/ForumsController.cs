namespace FitGym.Web.Controllers
{
    using FitGym.Data;
    using FitGym.Services.Data;
    using FitGym.Web.ViewModels.Forum;
    using Microsoft.AspNetCore.Mvc;

    public class ForumsController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public ForumsController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                Categories =
                   this.categoriesService.GetAll<IndexCategoryViewModel>(),
            };
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }
    }
}
