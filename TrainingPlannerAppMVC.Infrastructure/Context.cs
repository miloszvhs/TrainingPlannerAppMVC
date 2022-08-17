using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;
using TrainingPlannerAppMVC.Domain.Model;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Infrastructure
{
    public class Context : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Day> Days { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
        public DbSet<DayExercise> DayExercises { get; set; }
        public DbSet<DayExerciseCategory> DayExerciseCategories { get; set; }
        public DbSet<DayExerciseDetails> DayExerciseDetails { get; set; }
        public DbSet<DayExerciseSet> DayExerciseSets { get; set; }
        public DbSet<DayProduct> DayProducts { get; set; }
        public DbSet<DayProductDetails> DayProductDetails { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties())
                .Where(x => x.ClrType == typeof(decimal)))
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }

            builder.Entity<User>(x =>
            {
                x.Ignore(x => x.Email);
                x.Property(x => x.FirstName).IsRequired();
                x.Property(x => x.LastName).IsRequired();
                //specify that the Email property is an Owned Entity of the User entity type
                x.OwnsOne(x => x.UserEmail);
            });
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = string.Empty;
                        entry.Entity.CreatedOn = DateTime.Now;
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.ModifiedOn = DateTime.Now;
                        entry.Entity.StatusId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.ModifiedOn = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.ModifiedOn = DateTime.Now;
                        entry.Entity.InactivatedOn = DateTime.Now;
                        entry.Entity.InactivatedBy = string.Empty;
                        entry.Entity.StatusId = 0;
                        entry.State = EntityState.Modified;
                        break;
                }
            }

            return base.SaveChanges();
        }
    }
}
