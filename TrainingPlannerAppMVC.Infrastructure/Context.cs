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
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
        public DbSet<ExerciseDetails> ExerciseDetails { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(x => x.Day).WithOne(x => x.User)
                .HasForeignKey<Day>(x => x.UserId);

            builder.Entity<Product>()
                .HasOne(x => x.Calories).WithOne(x => x.Product)
                .HasForeignKey<Calories>(x => x.ProductId);
            //todo
            /*builder.Entity<ExerciseCategory>()
                .HasKey(x => x.ExerciseId)
                .*/
        }
    }
}
