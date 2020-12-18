namespace FitGym.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    using FitGym.Data.Common.Repositories;
    using FitGym.Data.Models;
    using FitGym.Services.Mapping;
    using FitGym.Web.ViewModels;
    using FitGym.Web.ViewModels.Posts;
    using Moq;
    using Xunit;

    public class PostsServiceTests
    {
        public PostsServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public async Task CreateMethodShouldAddNewPost()
        {
            var list = new List<Post>();
            var mockRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => list.Add(post));
            var service = new PostsService(mockRepo.Object);
            await service.CreateAsync("Test", "Test", 1, "1");

            Assert.Single(list);
        }

        [Fact]
        public void GetByCategoryIdShouldReturnAllPostsInCategory()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockRepo.Setup(x => x.All())
                .Returns(new List<Post>()
                {
                    new Post
                    {
                        Content = "Test",
                        Title = "Test",
                        CategoryId = 1,
                        Category = new Category(),
                        UserId = "Test",
                        User = new ApplicationUser(),
                    },
                    new Post
                    {
                        Content = "Test2",
                        Title = "Test2",
                        CategoryId = 1,
                        Category = new Category(),
                        UserId = "Test2",
                        User = new ApplicationUser(),
                    },
                    new Post
                    {
                        Content = "Test3",
                        Title = "Test3",
                        CategoryId = 2,
                        Category = new Category(),
                        UserId = "Test3",
                        User = new ApplicationUser(),
                    },
                }.AsQueryable());

            var service = new PostsService(mockRepo.Object);

            var result = service.GetByCategoryId<PostViewModel>(1);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetByIdIdShouldReturnCorrectPost()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockRepo.Setup(x => x.All())
                .Returns(new List<Post>()
                {
                    new Post
                    {
                        Id = 1,
                        Content = "Test",
                        Title = "Test",
                        CategoryId = 1,
                        Category = new Category(),
                        UserId = "Test",
                        User = new ApplicationUser(),
                    },
                    new Post
                    {
                        Id = 2,
                        Content = "Test2",
                        Title = "Test2",
                        CategoryId = 1,
                        Category = new Category(),
                        UserId = "Test2",
                        User = new ApplicationUser(),
                    },
                }.AsQueryable());

            var service = new PostsService(mockRepo.Object);

            var result = service.GetById<PostViewModel>(2);

            Assert.Equal("Test2", result.Title);
        }

        [Fact]
        public void GetCountByCategoryIdShouldReturnCorrectCount()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockRepo.Setup(x => x.All())
                .Returns(new List<Post>()
                {
                    new Post
                    {
                        Content = "Test",
                        Title = "Test",
                        CategoryId = 1,
                        Category = new Category(),
                        UserId = "Test",
                        User = new ApplicationUser(),
                    },
                    new Post
                    {
                        Content = "Test2",
                        Title = "Test2",
                        CategoryId = 1,
                        Category = new Category(),
                        UserId = "Test2",
                        User = new ApplicationUser(),
                    },
                    new Post
                    {
                        Content = "Test3",
                        Title = "Test3",
                        CategoryId = 2,
                        Category = new Category(),
                        UserId = "Test3",
                        User = new ApplicationUser(),
                    },
                }.AsQueryable());

            var service = new PostsService(mockRepo.Object);

            var result = service.GetCountByCategoryId(1);
            var result2 = service.GetCountByCategoryId(2);

            Assert.Equal(2, result);
            Assert.Equal(1, result2);
        }
    }
}
