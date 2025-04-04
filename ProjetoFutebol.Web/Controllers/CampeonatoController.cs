using Microsoft.AspNetCore.Mvc;

namespace ProjetoFutebol.Web.Controllers
{
    public class CampeonatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
