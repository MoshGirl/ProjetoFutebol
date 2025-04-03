using Microsoft.AspNetCore.Authentication.Cookies;
using ProjetoFutebol.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Auth/Index";
    options.LogoutPath = "/Auth/Logout";
    options.AccessDeniedPath = "/Auth/AcessoNegado";
    options.ExpireTimeSpan = TimeSpan.FromHours(1);
});

builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddScoped<AuthService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Auth/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Index}/{id?}");

app.Run();