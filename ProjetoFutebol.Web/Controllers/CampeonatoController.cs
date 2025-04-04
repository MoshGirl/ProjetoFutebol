using Microsoft.AspNetCore.Mvc;
using ProjetoFutebol.Web.Interfaces;

namespace ProjetoFutebol.Web.Controllers
{
    public class CampeonatoController : Controller
    {

        private readonly ICampeonatoService _campeonatoService;

        public CampeonatoController(ICampeonatoService campeonatoService)
        {
            _campeonatoService = campeonatoService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _campeonatoService.ObterCampeonatosComPartidasAsync();
            return View(model);
        }
    }
}