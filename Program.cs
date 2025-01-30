using Microsoft.EntityFrameworkCore;
using MVC.Data;

// Initialize instance of the web application builder class which sets up the configurations, services and the webserver.
var builder = WebApplication.CreateBuilder(args);

// Add MVC-services to the dependency injection container with support for controllers and views.
// Allows the application for handling incoming HTTP requests and renders HTML views.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MVCContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

// Compile the app, creating a web application instance which can be configured and ran.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
