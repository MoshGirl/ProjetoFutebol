using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProjetoFutebol.Web.Interfaces;
using ProjetoFutebol.Web.Response;
using ProjetoFutebol.Web.ViewModels;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace ProjetoFutebol.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IApiService _apiService;

        public AuthService(IHttpContextAccessor httpContextAccessor, IApiService apiService)
        {
            _httpContextAccessor = httpContextAccessor;
            _apiService = apiService;
        }

        public async Task<bool> AutenticarUsuario(AuthViewModel model)
        {
            var loginData = new { Email = model.Email, Senha = model.Senha };

            var response = await _apiService.PostAsync<LoginResponse>("auth/login", loginData);

            if (response != null)
            {
                var session = _httpContextAccessor.HttpContext?.Session;
                session?.SetString("AuthToken", response.Token);
                return true;
            }
            return false;
        }

        public async Task<(ClaimsIdentity? claimsIdentity, AuthenticationProperties? authProperties)> ConfigurarCookies(string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties { IsPersistent = true };

            return (claimsIdentity, authProperties);
        }
    }
}