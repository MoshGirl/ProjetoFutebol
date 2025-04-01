using Microsoft.AspNetCore.Mvc;
using ProjetoFutebol.Aplicacao.Servicos;

namespace ProjetoFutebol.WebAPI.Controllers
{
    [Route("api/teste")]
    [ApiController]
    public class FutebolController : ControllerBase
    {
        private readonly ApiFutebolService _apiFutebolService;

        public FutebolController(ApiFutebolService apiFutebolService)
        {
            _apiFutebolService = apiFutebolService;
        }

        [HttpGet]
        public async Task<IActionResult> TestarApi()
        {
            var data = await _apiFutebolService.ObterAreasAsync();
            return Ok(data);
        }
    }
}
