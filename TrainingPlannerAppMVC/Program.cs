using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainingPlannerAppMVC.Application;
using TrainingPlannerAppMVC.Domain.Model;
using TrainingPlannerAppMVC.Infrastructure;
using TrainingPlannerAppMVC.Infrastructure.Binders;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

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
}).AddRoles<IdentityRole<Guid>>()
.AddEntityFrameworkStores<Context>();

//Services DI
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

//Authentications and external login
builder.Services.AddAuthentication().AddGoogle(opt =>
{
    IConfigurationSection googleAuthNSection = config.GetSection("Authentication:Google");
    opt.ClientId = googleAuthNSection["ClientId"];
    opt.ClientSecret = googleAuthNSection["ClientSecret"];
});

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("CanEditUser", policy =>
    {
        policy.RequireClaim("EditUser");
        policy.RequireClaim("ShowUser");
        policy.RequireRole("Admin");
    });
});

//Binders
builder.Services.AddControllers(x => { x.ModelBinderProviders.Insert(0, new DecimalBinderProvider()); });

//Validations
builder.Services.AddFluentValidation();
builder.Services.AddValidations();

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