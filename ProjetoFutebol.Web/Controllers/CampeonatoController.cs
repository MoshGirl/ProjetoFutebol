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

        public IActionResult Index()
        {
            var model = _campeonatoService.ObterCampeonatosComPartidasAsync();
            return View(model);
        }
    }
}