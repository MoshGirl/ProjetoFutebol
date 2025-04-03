using Microsoft.AspNetCore.Authentication.Cookies;
using ProjetoFutebol.Web.Interfaces;
using ProjetoFutebol.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura��o da Autentica��o
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Index";
        options.LogoutPath = "/Auth/Logout";
        options.AccessDeniedPath = "/Auth/AcessoNegado";
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
    });

// Configura��o de Sess�o
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Inje��o de Depend�ncias
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();

// Configura��o do HttpClient
builder.Services.AddHttpClient<IAuthService, AuthService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7015/api/");
});

// Constru��o do Aplicativo
var app = builder.Build();

// Configura��o do Pipeline de Requisi��o
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Auth/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Middleware de Sess�o e Autentica��o
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

// Configura��o das Rotas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Index}/{id?}");

app.Run();