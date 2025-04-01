using Microsoft.AspNetCore.Mvc;
using ProjetoFutebol.Aplicacao.Servicos;
using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Interfaces;

namespace ProjetoFutebol.WebAPI.Controllers
{
    [Route("api/Futebol")]
    [ApiController]
    public class FutebolController : ControllerBase
    {
        private readonly IApiFutebolService _apiFutebolService;
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
                var data = await _apiFutebolService.ObterDadosAsync<AreasDTO>("areas");
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
                var data = await _apiFutebolService.ObterDadosAsync<CompeticoesDTO>("competitions");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter competições.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        [HttpGet("PartidasHoje")]
        public async Task<IActionResult> ObterPartidasDeHoje()
        {
            try
            {
                var data = await _apiFutebolService.ObterDadosAsync<PartidasDTO>("matches");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter partidas.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        [HttpGet("CompeticaoEspecifica")]
        public async Task<IActionResult> ObterCompeticaoEspecifica(string codigoCompeticao)
        {
            try
            {
                var data = await _apiFutebolService.ObterDadosAsync<CompeticaoEspecificaDTO>("matches", codigoCompeticao);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter partidas.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }
    }
}