namespace FitGym.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using FitGym.Data.Common.Repositories;
    using FitGym.Data.Models;
    using FitGym.Services.Mapping;
    using FitGym.Web.ViewModels;
    using FitGym.Web.ViewModels.Categories;
    using FitGym.Web.ViewModels.Forum;
    using Moq;
    using Xunit;

    public class CategoriesServiceTests
    {
        public CategoriesServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public async Task CreateMethodShouldAddNewCategorie()
        {
            var list = new List<Category>();
            var mockRepo = new Mock<IDeletableEntityRepository<Category>>();
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Category>())).Callback((Category category) => list.Add(category));
            var service = new CategoriesService(mockRepo.Object);
            await service.CreateAsync("Cardio", "Cardio", "Description", "urlUrlurl");

            Assert.Single(list);
        }

        [Fact]
        public void GetAllShouldReturnAllCategories()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Category>>();
            mockRepo.Setup(x => x.All())
                .Returns(new List<Category>()
                {
                    new Category
                    {
                        Name = "Test",
                        Title = "Test",
                        Description = "Test",
                        ImageUrl = "Test",
                    },
                    new Category
                    {
                        Name = "Test2",
                        Title = "Test2",
                        Description = "Test2",
                        ImageUrl = "Test2",
                    },
                }.AsQueryable());
            var service = new CategoriesService(mockRepo.Object);
            var result = service.GetAll<IndexCategoryViewModel>();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetByNameShouldReturnCorrectCategory()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Category>>();
            mockRepo.Setup(x => x.All())
                .Returns(new List<Category>()
                {
                    new Category
                    {
                        Name = "Test",
                        Title = "Test",
                        Description = "Test",
                        ImageUrl = "Test",
                    },
                    new Category
                    {
                        Name = "Test2",
                        Title = "Test2",
                        Description = "Test2",
                        ImageUrl = "Test2",
                    },
                }.AsQueryable());
            var service = new CategoriesService(mockRepo.Object);
            var result = service.GetByName<CategoryViewModel>("Test2");

            Assert.Equal("Test2", result.Title);
        }
    }
}
