using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TrainingPlannerAppMVC.Application;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm.DayExerciseVm;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm.UserExerciseVm;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm.DayProductVm;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm.UserProductVm;
using TrainingPlannerAppMVC.Application.ViewModels.UserVm;
using TrainingPlannerAppMVC.Domain.Model;
using TrainingPlannerAppMVC.Infrastructure;
using TrainingPlannerAppMVC.Infrastructure.Binders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequiredLength = 8;
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
    }
).AddEntityFrameworkStores<Context>();

//Services DI
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

//Binders
builder.Services.AddControllers(x => { x.ModelBinderProviders.Insert(0, new DecimalBinderProvider()); });

//Validations
builder.Services.AddFluentValidation();
builder.Services.AddTransient<IValidator<NewUserVm>, NewUserValidation>();
builder.Services.AddTransient<IValidator<NewProductVm>, NewProductValidation>();
builder.Services.AddTransient<IValidator<ProductDetailsVm>, ProductDetailsValidation>();
builder.Services.AddTransient<IValidator<ProductCaloriesVm>, ProductCaloriesValidation>();
builder.Services.AddTransient<IValidator<NewExerciseVm>, NewExerciseValidation>();
builder.Services.AddTransient<IValidator<ExerciseCategoryVm>, ExerciseCategoryValidation>();
builder.Services.AddTransient<IValidator<DayExerciseSetVm>, DayExerciseSetValidation>();
builder.Services.AddTransient<IValidator<NewDayExerciseVm>, NewDayExerciseValidation>();
builder.Services.AddTransient<IValidator<NewDayProductVm>, NewDayProductValidation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute("product",
    "product",
    new { controller = "Product", action = "Index" });
app.MapControllerRoute("exercise",
    "exercise",
    new { controller = "Exercise", action = "Index" });
app.MapControllerRoute("day",
    "day",
    new { controller = "Day", action = "Index" });
app.MapRazorPages();

app.Run();