using Microsoft.AspNetCore.Authentication;
using ProjetoFutebol.Web.ViewModels;
using System.Security.Claims;

namespace ProjetoFutebol.Web.Interfaces
{
    public interface IAuthService
    {
        Task<bool> AutenticarUsuario(AuthViewModel model);
        Task<(ClaimsIdentity? claimsIdentity, AuthenticationProperties? authProperties)> ConfigurarCookies(AuthViewModel model);
    }
}