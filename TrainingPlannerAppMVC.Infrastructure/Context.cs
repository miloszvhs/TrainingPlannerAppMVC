using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Day> Days { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Calories> Calories { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
        public DbSet<ExerciseDetails> ExerciseDetails { get; set; }

        public Context(DbContextOptions options) : base(options)
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
                x.Property(x => x.Email).IsRequired();
                x.Property(x => x.FirstName).IsRequired();
                x.Property(x => x.LastName).IsRequired();
                x.Property(x => x.AccountName).IsRequired();
                x.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
                x.Property(x => x.UpdatedDate).ValueGeneratedOnUpdate();

                x.HasMany(x => x.Days)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
            });

            builder.Entity<Product>()
                .HasOne(x => x.Calories)
                .WithOne(x => x.Product)
                .HasForeignKey<Calories>(x => x.ProductId);

            builder.Entity<Day>(x =>
            {
                x.Property(x => x.Date)
                .ValueGeneratedOnAdd();

                x.HasMany(x => x.Exercises)
                .WithOne(x => x.Day)
                .HasForeignKey(x => x.DayId);

                x.HasMany(x => x.Products)
                .WithOne(x => x.Day)
                .HasForeignKey(x => x.DayId);
            });

            builder.Entity<ExerciseCategory>()
                .HasMany(x => x.Exercises)
                .WithOne(x => x.ExerciseCategory)
                .HasForeignKey(x => x.ExerciseCategoryId);

            builder.Entity<ExerciseDetails>()
                .HasMany(x => x.Sets)
                .WithOne(x => x.ExerciseDetails)
                .HasForeignKey(x => x.ExerciseDetailsId);

            builder.Entity<Exercise>()
                .HasOne(x => x.ExerciseDetails)
                .WithOne(x => x.Exercise)
                .HasForeignKey<ExerciseDetails>(x => x.ExerciseId);
        }
    }
}
