using Dal;
using Dal.Interfaces;
using Dal.Models;
using Dal.Repositories;
using Microsoft.EntityFrameworkCore;
using Mvc.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<ICrudRepository<User, int>, UserRepository>();
builder.Services.AddScoped<ICrudRepository<Project, int>, ProjectRepository>();
builder.Services.AddScoped<ICrudRepository<TaskItem, int>, TaskRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using IServiceScope scope = app.Services.CreateScope();
IServiceProvider service = scope.ServiceProvider;
try
{
    DataContext context = service.GetRequiredService<DataContext>();
    context.Database.Migrate();
    if (app.Environment.IsDevelopment())
    {
        UserSeed.SeedUsers(context);
    }
}
catch (Exception e)
{
    var logger = service.GetRequiredService<ILogger<Program>>();
    logger.LogError(e, "An error occurred seeding the database");
}

app.Run();