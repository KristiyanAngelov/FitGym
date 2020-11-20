namespace FitGym.Web.Controllers
{
    using System.Threading.Tasks;

    using FitGym.Data.Models;
    using FitGym.Services.Data;
    using FitGym.Services.Data.Interfaces;
    using FitGym.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(IPostsService postsService, ICategoriesService categoriesService, UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        public IActionResult ById(int id)
        {
            var postViewModel = this.postsService.GetById<PostViewModel>(id);
            if (postViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(postViewModel);
        }

        [Authorize]
        public IActionResult Create(int id)
        {
            var viewModel = new PostCreateInputModel
            {
                CategoryId = id,
            };
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(int id, PostCreateInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            input.CategoryId = id;
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var postId = await this.postsService.CreateAsync(input.Title, input.Content, input.CategoryId, user.Id);
            this.TempData["InfoMessage"] = "Forum post created!";
            return this.RedirectToAction(nameof(this.ById), new { id = postId });
        }

        [AllowAnonymous]
        public IActionResult AllPostsInCategory(int id)
        {
            var viewModel = new AllPostsInCategoryViewModel
            {
                CategoryId = id,
                Posts = this.postsService.GetByCategoryId<PostViewModel>(id),
            };
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }
    }
}
