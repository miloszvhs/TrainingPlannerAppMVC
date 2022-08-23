using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.Services;

namespace TrainingPlannerAppMVC.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IDayService, DayService>();
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IExerciseService, ExerciseService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}