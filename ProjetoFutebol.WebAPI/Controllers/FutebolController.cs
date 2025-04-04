using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFutebol.Aplicacao.Servicos;
using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Entidades;
using ProjetoFutebol.Dominio.Interfaces;

namespace ProjetoFutebol.WebAPI.Controllers
{
    [Route("api/Futebol")]
    [ApiController]
    [Authorize]
    public class FutebolController : ControllerBase
    {
        private readonly IApiFutebolService _apiFutebolService;
        private readonly IRepository<Competicao> _repositoryCompeticao;
        private readonly IRepository<Equipe> _repositoryEquipe;
        private readonly IRepository<EquipeCompeticao> _repositoryEquipeCompeticao;
        private readonly ILogger<FutebolController> _logger;

        public FutebolController(ApiFutebolService apiFutebolService, ILogger<FutebolController> logger, IRepository<Competicao> repositoryCompeticao, IRepository<Equipe> repositoryEquipe, IRepository<EquipeCompeticao> repositoryEquipeCompeticao)
        {
            _apiFutebolService = apiFutebolService;
            _logger = logger;
            _repositoryCompeticao = repositoryCompeticao;
            _repositoryEquipe = repositoryEquipe;
            _repositoryEquipeCompeticao = repositoryEquipeCompeticao;
        }

        [HttpGet("areas")]
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

        [HttpGet("competicoes")]
        public async Task<IActionResult> ObterCompeticoes()
        {
            try
            {
                var competicaos = await _repositoryCompeticao.ObterTodosAsync();
                var equipesCompeticao = await _repositoryEquipeCompeticao.ObterTodosAsync();
                var equipes = await _repositoryEquipe.ObterTodosAsync();

                var resultado = competicaos
                                .GroupJoin(
                                    equipesCompeticao,
                                    c => c.CompeticaoID,
                                    ec => ec.CompeticaoID,
                                    (c, ecs) => new
                                    {
                                        c.CompeticaoID,
                                        c.NomeCompeticao,
                                        c.Codigo,
                                        c.TipoCompeticao,
                                        c.Temporada,
                                        c.PaisID,
                                        c.Emblema,
                                        Equipes = ecs.Join(
                                            equipes,
                                            ec => ec.EquipeID,
                                            e => e.EquipeID,
                                            (ec, e) => new
                                            {
                                                e.EquipeID,
                                                e.NomeEquipe,
                                                e.NomeAbreviado,
                                                e.Sigla,
                                                e.Escudo
                                            }).ToList()
                                    }).ToList();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter competições.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        [HttpGet("equipes")]
        public async Task<IActionResult> ObterEquipes()
        {
            try
            {
                var equipes = await _repositoryEquipe.ObterTodosAsync();
                var equipesCompeticao = await _repositoryEquipeCompeticao.ObterTodosAsync();
                var competicoes = await _repositoryCompeticao.ObterTodosAsync();

                var resultado = equipes
                    .GroupJoin(
                        equipesCompeticao,
                        e => e.EquipeID,
                        ec => ec.EquipeID,
                        (e, ecs) => new
                        {
                            e.EquipeID,
                            e.NomeEquipe,
                            e.NomeAbreviado,
                            e.Sigla,
                            e.Escudo,
                            Competicoes = ecs.Join(
                                competicoes,
                                ec => ec.CompeticaoID,
                                c => c.CompeticaoID,
                                (ec, c) => new
                                {
                                    c.CompeticaoID,
                                    c.NomeCompeticao,
                                    c.Codigo,
                                    c.TipoCompeticao,
                                    c.Temporada,
                                    c.Emblema
                                }).ToList()
                        }).ToList();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter competições.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        [HttpGet("partidas-hoje")]
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

        [HttpGet("competicao-especifica")]
        public async Task<IActionResult> ObterCompeticaoEspecifica(string codigoCompeticao)
        {
            try
            {
                var data = await _apiFutebolService.ObterDadosAsync<CompeticaoEspecificaDTO>("competitions", codigoCompeticao);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter partidas.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        [HttpGet("time-especifico")]
        public async Task<IActionResult> ObterTimeEspecifico(string codigoTime)
        {
            try
            {
                var data = await _apiFutebolService.ObterDadosAsync<TimeEspecificoDTO>("teams", codigoTime);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter partidas.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        [HttpGet("times-competicao")]
        public async Task<IActionResult> ObterTimesPorCompeticao(string codigoCompeticao)
        {
            try
            {
                var data = await _apiFutebolService.ObterDadosAsync<TimesCompeticaoDTO>("competitions", codigoCompeticao + "/teams");
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