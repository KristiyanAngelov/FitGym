namespace FitGym.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using FitGym.Data;
    using FitGym.Data.Common.Repositories;
    using FitGym.Data.Models;
    using FitGym.Data.Repositories;
    using FitGym.Services.Mapping;
    using FitGym.Web.ViewModels;
    using FitGym.Web.ViewModels.Users;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class UsersServiceTests
    {
        public UsersServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public void GetAllUsersShouldReturnAllUsers()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockRepo.Setup(x => x.All())
                .Returns(new List<ApplicationUser>
                {
                new ApplicationUser
                {
                    Id = "1",
                    UserName = "Test1",
                    Email = "test@email.com",
                    PasswordHash = "12345678",
                    CreatedOn = DateTime.Now,
                },
                new ApplicationUser
                {
                    Id = "2",
                    UserName = "Test2",
                    Email = "test@email.com",
                    PasswordHash = "12345678",
                    CreatedOn = DateTime.Now,
                },
                }.AsQueryable());
            var userManager = new Mock<FakeUserManager>();
            var service = new UsersService(mockRepo.Object, userManager.Object);

            var result = service.GetAllUsers();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetAllUsersWithTemplateShouldReturnAllUsers()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockRepo.Setup(x => x.All())
                .Returns(new List<ApplicationUser>
                {
                new ApplicationUser
                {
                    Id = "1",
                    UserName = "Test1",
                    Email = "test@email.com",
                    PasswordHash = "12345678",
                    CreatedOn = DateTime.Now,
                },
                new ApplicationUser
                {
                    Id = "2",
                    UserName = "Test2",
                    Email = "test@email.com",
                    PasswordHash = "12345678",
                    CreatedOn = DateTime.Now,
                },
                }.AsQueryable());
            var userManager = new Mock<FakeUserManager>();
            var service = new UsersService(mockRepo.Object, userManager.Object);

            var result = service.GetAllUsers<UserViewModel>();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetAllDeletedUsersShouldReturnAllDeletedUsers()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockRepo.Setup(x => x.AllWithDeleted())
                .Returns(new List<ApplicationUser>
                {
                new ApplicationUser
                {
                    Id = "1",
                    UserName = "Test1",
                    Email = "test@email.com",
                    PasswordHash = "12345678",
                    CreatedOn = DateTime.Now,
                    IsDeleted = true,
                },
                new ApplicationUser
                {
                    Id = "2",
                    UserName = "Test2",
                    Email = "test@email.com",
                    PasswordHash = "12345678",
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                },
                new ApplicationUser
                {
                    Id = "2",
                    UserName = "Test2",
                    Email = "test@email.com",
                    PasswordHash = "12345678",
                    CreatedOn = DateTime.Now,
                    IsDeleted = true,
                },
                }.AsQueryable());

            var userManager = new Mock<FakeUserManager>();
            var service = new UsersService(mockRepo.Object, userManager.Object);

            var result = service.GetAllDeletedUsers<UserViewModel>();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetUserByIdShouldReturnCorrectUser()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockRepo.Setup(x => x.All())
                .Returns(new List<ApplicationUser>
                {
                new ApplicationUser
                {
                    Id = "1",
                    UserName = "Test1",
                    Email = "test@email.com",
                    PasswordHash = "12345678",
                    CreatedOn = DateTime.Now,
                },
                new ApplicationUser
                {
                    Id = "2",
                    UserName = "Test2",
                    Email = "test@email.com",
                    PasswordHash = "12345678",
                    CreatedOn = DateTime.Now,
                },
                }.AsQueryable());
            var userManager = new Mock<FakeUserManager>();
            var service = new UsersService(mockRepo.Object, userManager.Object);

            var result = service.GetUserById("2");
            var result2 = service.GetUserById<UserViewModel>("1");

            Assert.Equal("Test2", result.UserName);
            Assert.Equal("Test1", result2.UserName);
        }

        [Fact]
        public async Task DeleteUserShouldMakeUserIsDeleted()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var db = new ApplicationDbContext(options);
            var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(db);

            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "Test1",
                Email = "test@email.com",
                PasswordHash = "12345678",
                CreatedOn = DateTime.Now,
            };

            db.Users.Add(user);
            db.SaveChanges();

            var userManager = new Mock<FakeUserManager>();
            var service = new UsersService(usersRepository, userManager.Object);

            await service.DeleteUser("1");

            Assert.True(user.IsDeleted);
        }
    }
}
