using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProjetoFutebol.Web.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjetoFutebol.Web.Services
{
    public class AuthService
    {
        public AuthService()
        {
                
        }

        internal async Task<bool> AutenticarUsuario(string email, string senha)
        {
            await Task.Delay(500);
            return email == "admin@email.com" && senha == "senha123";
        }

        internal async Task<(ClaimsIdentity? claimsIdentity, AuthenticationProperties? authProperties)> ConfigurarCookies(AuthViewModel model)
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