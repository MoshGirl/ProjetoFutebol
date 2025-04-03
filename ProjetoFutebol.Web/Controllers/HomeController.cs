using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFutebol.Web.Interfaces;
using ProjetoFutebol.Web.Models;
using System.Diagnostics;

namespace ProjetoFutebol.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPartidaService _partidaService;

        public HomeController(ILogger<HomeController> logger, IPartidaService partidaService)
        {
            _logger = logger;
            _partidaService = partidaService;
        }

        public async Task<IActionResult> Index()
        {
            var partidas = await _partidaService.ObterPartidasDeHojeAsync();
            return View(partidas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}