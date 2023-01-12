using Microsoft.EntityFrameworkCore;
using Test.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var BigProjectContextconnectionString = builder.Configuration.GetConnectionString("Test");
builder.Services.AddDbContext<BigProjectContext>(options =>
	options.UseSqlServer(BigProjectContextconnectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Members}/{action=Index}/{id?}");

app.Run();
