using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProjetoFutebol.Web.Interfaces;
using ProjetoFutebol.Web.ViewModels;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace ProjetoFutebol.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> AutenticarUsuario(AuthViewModel model)
        {
            var loginData = new { Email = model.Email, Senha = model.Senha };

            var content = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsJsonAsync("auth/login", model);

            if (!response.IsSuccessStatusCode)
                return false;

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            if (result != null)
            {
                var session = _httpContextAccessor.HttpContext?.Session;
                session?.SetString("AuthToken", result.Token);
                return true;
            }
            return false;
        }

        public async Task<bool> CadastrarAsync(CadastroViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/registrar", model);
            return response.IsSuccessStatusCode;
        }

        public void Logout()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            session?.Remove("AuthToken");
        }

        public class LoginResponse
        {
            public string Token { get; set; }
        }

        public async Task<(ClaimsIdentity? claimsIdentity, AuthenticationProperties? authProperties)> ConfigurarCookies(AuthViewModel model)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Admin"),
                new Claim(ClaimTypes.Email, model.Email)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties { IsPersistent = true };

            return (claimsIdentity, authProperties);
        }
    }
}