using M_News.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddSession();
/*builder.Services.Configure<ReCAPTCHASettings>(Configuration.GetSection("RecaptchaSettings"));*/
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});





builder.Services.AddConfiguration();
builder.Services.AddMvc();
builder.Services.AddAuthentication(
	CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(x=>
	{
		x.LoginPath = "/Login/Login";
		x.ExpireTimeSpan = TimeSpan.FromMinutes(10);
	}
	);

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

app.UseSession();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
