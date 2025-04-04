using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProjetoFutebol.Web.ViewModels;
using ProjetoFutebol.Web.Services;
using System.Security.Claims;
using System.Net.Http;
using ProjetoFutebol.Web.Interfaces;

namespace ProjetoFutebol.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            if(User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index", model);
                }

                bool loginValido = await _authService.AutenticarUsuario(model);

                if (!loginValido)
                {
                    ModelState.AddModelError("Senha", "Usuário ou senha inválidos");
                    return View("Index", model);
                }

                var tokenSalvo = HttpContext.Session.GetString("AuthToken");

                var (claimsIdentity, authProperties) = await _authService.ConfigurarCookies(model.Email);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = $"Erro ao fazer login: {ex.Message}";
                return RedirectToAction("Index");
            }            
        }        

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}