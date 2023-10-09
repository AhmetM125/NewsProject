using M_News.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

//Context Implementation
/*builder.Services.AddDbContext<NEUContext>(option =>
{
	option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});*/

builder.Services.AddSession();
builder.Services.AddMvc();


builder.Services.AddConfiguration(); // Configuration for Manager Service and DAL

//Authentication For User 
builder.Services.AddAuthentication(
	CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(x=>
	{
		x.LoginPath = "/Login/Login";
		x.ExpireTimeSpan = TimeSpan.FromMinutes(10);
	}
	);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
