using Microsoft.AspNetCore.Mvc;
using ProjetoFutebol.Aplicacao.Servicos;

namespace ProjetoFutebol.WebAPI.Controllers
{
    [Route("api/Futebol")]
    [ApiController]
    public class FutebolController : ControllerBase
    {
        private readonly ApiFutebolService _apiFutebolService;
        private readonly ILogger<FutebolController> _logger;

        public FutebolController(ApiFutebolService apiFutebolService, ILogger<FutebolController> logger)
        {
            _apiFutebolService = apiFutebolService;
            _logger = logger;
        }

        [HttpGet("Areas")]
        public async Task<IActionResult> ObterAreas()
        {
            try
            {
                var data = await _apiFutebolService.ObterAreasAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter áreas.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        [HttpGet("Competicoes")]
        public async Task<IActionResult> ObterCompeticoes()
        {
            try
            {
                var data = await _apiFutebolService.ObterCompeticoesAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter competições.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }
    }
}