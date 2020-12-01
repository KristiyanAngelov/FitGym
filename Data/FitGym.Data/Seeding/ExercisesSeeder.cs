namespace FitGym.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FitGym.Data.Models;
    using FitGym.Data.Models.Enums;

    public class ExercisesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Execises.Any())
            {
                return;
            }

            var exercises = new List<(string Name, string VideoUrl, Difficulty Difficulty, ExerciseType Type)>
            {
                ("Bench Press", "https://www.youtube.com/watch?v=rT7DgCr-3pg&t=2s&ab_channel=ScottHermanFitness", Difficulty.Medium,ExerciseType.Chest),
                ("Dips", "https://www.youtube.com/watch?v=2z8JmcrW-As&ab_channel=Calisthenicmovement", Difficulty.Medium, ExerciseType.Chest),
                ("Dumbbell Shoulder Press", "https://www.youtube.com/watch?v=qEwKCR5JCog&ab_channel=ScottHermanFitness", Difficulty.Easy, ExerciseType.Shoulder),
            };

            foreach (var exercise in exercises)
            {
                await dbContext.Execises.AddAsync(new Exercise
                {
                    Name = exercise.Name,
                    VideoUrl = exercise.VideoUrl,
                    Difficulty = exercise.Difficulty,
                    Type = exercise.Type,
                });

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
