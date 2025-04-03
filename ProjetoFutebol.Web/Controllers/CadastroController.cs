using Microsoft.AspNetCore.Mvc;
using ProjetoFutebol.Web.Interfaces;
using ProjetoFutebol.Web.ViewModels;

namespace ProjetoFutebol.Web.Controllers
{
    public class CadastroController : Controller
    {
        private readonly ICadastroService _cadastroService;
        private readonly IAuthService _authService;

        public CadastroController(ICadastroService cadastroService, IAuthService authService)
        {
            _cadastroService = cadastroService;
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(CadastroViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index", model);
                }

                var cadastroValido = await _cadastroService.CadastrarNovoUsuario(model);

                if (cadastroValido.Status != 200)
                    ModelState.AddModelError("Email", "Usuário ou senha inválidos");

                var (claimsIdentity, authProperties) = await _authService.ConfigurarCookies(model.Email);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao processar seu cadastro.");
                return View("Index", model);
            }
        }
    }
}