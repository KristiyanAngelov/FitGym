namespace FitGym.Web.Controllers
{
    using FitGym.Services.Data;
    using FitGym.Services.Data.Interfaces;
    using FitGym.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IPostsService postsService;

        public CategoriesController(ICategoriesService categoriesService, IPostsService postsService)
        {
            this.categoriesService = categoriesService;
            this.postsService = postsService;
        }

        public IActionResult ByName(string name, int page = 1)
        {
            var viewModel =
                this.categoriesService.GetByName<CategoryViewModel>(name);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateInputModel input)
        {
            //TODO IMPLEMENT POST METHOD
        }
    }
}
