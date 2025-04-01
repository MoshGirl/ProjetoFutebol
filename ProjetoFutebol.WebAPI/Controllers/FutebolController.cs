using Microsoft.AspNetCore.Mvc;
using ProjetoFutebol.Aplicacao.Servicos;

namespace ProjetoFutebol.WebAPI.Controllers
{
    [Route("api/FutebolAPI")]
    [ApiController]
    public class FutebolController : ControllerBase
    {
        private readonly ApiFutebolService _apiFutebolService;

        public FutebolController(ApiFutebolService apiFutebolService)
        {
            _apiFutebolService = apiFutebolService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterAreas()
        {
            var data = await _apiFutebolService.ObterAreasAsync();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> ObterCompeticoes()
        {
            var data = await _apiFutebolService.ObterCompeticoesAsync();
            return Ok(data);
        }
    }
}
