using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.Services;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm.DayExerciseVm;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm.UserExerciseVm;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm.DayProductVm;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm.UserProductVm;
using TrainingPlannerAppMVC.Application.ViewModels.UserVm;

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
    
    public static IServiceCollection AddValidations(this IServiceCollection services)
    {
        services.AddTransient<IValidator<NewUserVm>, NewUserValidation>();                  
        services.AddTransient<IValidator<NewProductVm>, NewProductValidation>();            
        services.AddTransient<IValidator<ProductDetailsVm>, ProductDetailsValidation>();    
        services.AddTransient<IValidator<ProductCaloriesVm>, ProductCaloriesValidation>();  
        services.AddTransient<IValidator<NewExerciseVm>, NewExerciseValidation>();          
        services.AddTransient<IValidator<ExerciseCategoryVm>, ExerciseCategoryValidation>();
        services.AddTransient<IValidator<DayExerciseSetVm>, DayExerciseSetValidation>();    
        services.AddTransient<IValidator<NewDayExerciseVm>, NewDayExerciseValidation>();    
        services.AddTransient<IValidator<NewDayProductVm>, NewDayProductValidation>();      
        return services;
    }
}