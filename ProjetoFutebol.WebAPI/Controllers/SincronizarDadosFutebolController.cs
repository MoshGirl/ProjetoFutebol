using Microsoft.AspNetCore.Mvc;
using ProjetoFutebol.Dominio.Interfaces;

namespace ProjetoFutebol.WebAPI.Controllers
{
    [Route("api/SincronizacaoFutebol")]
    [ApiController]
    public class SincronizarDadosFutebolController : ControllerBase
    {
        private readonly ISincronizarDadosFutebolService _sincronizacaoService;
        private readonly ILogger<SincronizarDadosFutebolController> _logger;

        public SincronizarDadosFutebolController(ISincronizarDadosFutebolService sincronizacaoService, ILogger<SincronizarDadosFutebolController> logger)
        {
            _sincronizacaoService = sincronizacaoService;
            _logger = logger;
        }

        [HttpPost("sincronizar-paises")]
        public async Task<IActionResult> SincronizarPaises()
        {
            try
            {
                int total = await _sincronizacaoService.SincronizarPaisesAsync();
                return Ok(new { mensagem = "Paises sincronizados com sucesso!", total });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao sincronizar países.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        [HttpPost("sincronizar-competicoes")]
        public async Task<IActionResult> SincronizarCompeticoes()
        {
            try
            {
                int total = await _sincronizacaoService.SincronizarCompeticaoPorPaises();
                return Ok(new { mensagem = "Competições sincronizados com sucesso!", total });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao sincronizar países.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        [HttpPost("sincronizar-times-por-competicao")]
        public async Task<IActionResult> SincronizarTimesPorCompeticoes(string codigoCompeticao)
        {
            try
            {
                int total = await _sincronizacaoService.SincronizarTimesPorCompeticao(codigoCompeticao);
                return Ok(new { mensagem = "Times sincronizados com sucesso!", total });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao sincronizar países.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }
    }
}