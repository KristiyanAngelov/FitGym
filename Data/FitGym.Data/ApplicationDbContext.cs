namespace FitGym.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using FitGym.Data.Common.Models;
    using FitGym.Data.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<ClientTrainer> ClientsTrainers { get; set; }

        public DbSet<TrainerWorkout> TrainerWorkouts { get; set; }

        public DbSet<ClientWorkout> ClientWorkouts { get; set; }

        public DbSet<Workout> Workouts { get; set; }

        public DbSet<Exercise> Execises { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            // Configure table relations
            builder
                .Entity<ClientTrainer>()
                .HasKey(x => new { x.ClientId, x.TrainerId });

            builder
                .Entity<ClientTrainer>()
                .HasOne(ct => ct.Client)
                .WithMany(c => c.Trainers)
                .HasForeignKey(ct => ct.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<ClientTrainer>()
                .HasOne(ct => ct.Trainer)
                .WithMany(t => t.Clients)
                .HasForeignKey(ct => ct.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<ClientWorkout>()
                .HasKey(x => new { x.ClientId, x.WorkoutId });

            builder
                .Entity<ClientWorkout>()
                .HasOne(uw => uw.Client)
                .WithMany(u => u.ClientWorkouts)
                .HasForeignKey(uw => uw.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<ClientWorkout>()
                .HasOne(cw => cw.CWorkout)
                .WithMany(w => w.Clients)
                .HasForeignKey(cw => cw.WorkoutId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<TrainerWorkout>()
                .HasKey(x => new { x.TrainerId, x.WorkoutId });

            builder
                .Entity<TrainerWorkout>()
                .HasOne(tw => tw.Trainer)
                .WithMany(t => t.TrainerWorkouts)
                .HasForeignKey(tw => tw.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<TrainerWorkout>()
                .HasOne(tw => tw.TWorkout)
                .WithMany(w => w.Trainers)
                .HasForeignKey(tw => tw.WorkoutId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<WorkoutExercise>()
                .HasKey(x => new { x.WorkoutId, x.ExerciseId });

            builder
                .Entity<WorkoutExercise>()
                .HasOne(we => we.Workout)
                .WithMany(w => w.Exercises)
                .HasForeignKey(we => we.WorkoutId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<WorkoutExercise>()
                .HasOne(we => we.Exercise)
                .WithMany(e => e.Workouts)
                .HasForeignKey(we => we.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            // var foreignKeys = entityTypes
            //    .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            // foreach (var foreignKey in foreignKeys)
            // {
            //    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            // }
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
