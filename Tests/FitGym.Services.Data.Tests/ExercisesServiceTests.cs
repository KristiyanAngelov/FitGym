using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace FitGym.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using FitGym.Data.Common.Repositories;
    using FitGym.Data.Models;
    using FitGym.Data.Models.Enums;
    using FitGym.Services.Mapping;
    using FitGym.Web.ViewModels;
    using FitGym.Web.ViewModels.Exercises;
    using Moq;

    public class ExercisesServiceTests
    {
        public ExercisesServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public async Task CreateShouldAddNewCategoryToDbAsync()
        {
            var list = new List<Exercise>();
            var mockRepo = new Mock<IDeletableEntityRepository<Exercise>>();
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Exercise>()))
                .Callback((Exercise exercise) => list.Add(exercise));
            var service = new ExercisesService(mockRepo.Object);
            await service.CreateAsync(new ExerciseCreateInputModel
            {
                Name = "Test",
                Difficulty = Difficulty.Easy,
                Type = ExerciseType.Abs,
                VideoUrl = "Test",
            });

            Assert.Single(list);
        }

        [Fact]
        public void FindByIDShouldReturnCorrectExercise()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Exercise>>();
            mockRepo.Setup(x => x.All())
                .Returns(new List<Exercise>()
                {
                    new Exercise
                    {
                        Id = "1",
                        Name = "Test1",
                        Difficulty = Difficulty.Easy,
                        Type = ExerciseType.Abs,
                        VideoUrl = "Test",
                    },
                    new Exercise
                    {
                        Id = "2",
                        Name = "Test2",
                        Difficulty = Difficulty.Easy,
                        Type = ExerciseType.Abs,
                        VideoUrl = "Test2",
                    },
                }.AsQueryable());

            var service = new ExercisesService(mockRepo.Object);

            var result1 = service.FindByID("1");
            var result2 = service.FindByID("2");

            Assert.Equal("Test1", result1.Name);
            Assert.Equal("Test2", result2.Name);
        }

        [Fact]
        public void GetAllExercisesShouldReturnAllExercises()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Exercise>>();
            mockRepo.Setup(x => x.All())
                .Returns(new List<Exercise>()
                {
                    new Exercise
                    {
                        Id = "1",
                        Name = "Test1",
                        Difficulty = Difficulty.Easy,
                        Type = ExerciseType.Abs,
                        VideoUrl = "Test",
                    },
                    new Exercise
                    {
                        Id = "2",
                        Name = "Test2",
                        Difficulty = Difficulty.Easy,
                        Type = ExerciseType.Abs,
                        VideoUrl = "Test2",
                    },
                }.AsQueryable());

            var service = new ExercisesService(mockRepo.Object);

            var result = service.GetAllExercises();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetAllExercisesTemplateShouldReturnAllExercisesWithTemplate()
        {
            var mockRepo = new Mock<IDeletableEntityRepository<Exercise>>();
            mockRepo.Setup(x => x.All())
                .Returns(new List<Exercise>()
                {
                    new Exercise
                    {
                        Id = "1",
                        Name = "Test1",
                        Difficulty = Difficulty.Easy,
                        Type = ExerciseType.Abs,
                        VideoUrl = "Test",
                    },
                    new Exercise
                    {
                        Id = "2",
                        Name = "Test2",
                        Difficulty = Difficulty.Easy,
                        Type = ExerciseType.Abs,
                        VideoUrl = "Test2",
                    },
                }.AsQueryable());

            var service = new ExercisesService(mockRepo.Object);

            var result = service.GetAllExercises<ExerciseViewModel>();

            Assert.Equal(2, result.Count());
        }
    }
}
