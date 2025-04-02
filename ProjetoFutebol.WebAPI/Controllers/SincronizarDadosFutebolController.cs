using Microsoft.AspNetCore.Mvc;
using ProjetoFutebol.Aplicacao.Servicos;
using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Entidades;
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
    }
}