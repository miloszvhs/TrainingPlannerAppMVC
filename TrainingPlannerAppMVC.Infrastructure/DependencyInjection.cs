using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Interface;
using TrainingPlannerAppMVC.Infrastructure.Repositories;

namespace TrainingPlannerAppMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDayRepository, DayRepository>();
            services.AddTransient<IDayExerciseRepository, DayExerciseRepository>();
            services.AddTransient<IDayProductRepository, DayProductRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IExerciseRepository, ExerciseRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
