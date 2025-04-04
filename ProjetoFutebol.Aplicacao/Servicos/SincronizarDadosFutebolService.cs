using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Entidades;
using ProjetoFutebol.Dominio.Interfaces;
using Microsoft.Extensions.Logging;
using ProjetoFutebol.Dominio.Interfaces.EntidadesInterface;

namespace ProjetoFutebol.Aplicacao.Servicos
{
    public class SincronizarDadosFutebolService : ISincronizarDadosFutebolService
    {
        private readonly IApiFutebolService _apiFutebolService;
        private readonly IPaisService _paisService;
        private readonly ICompeticaoService _competicaoService;
        private readonly IEquipeService _equipeService;
        private readonly IPartidaService _partidaService;
        private readonly ILogger<SincronizarDadosFutebolService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public SincronizarDadosFutebolService(IApiFutebolService apiFutebolService, IPaisService paisService, ILogger<SincronizarDadosFutebolService> logger, IUnitOfWork unitOfWork, ICompeticaoService competicaoService, IEquipeService equipeService, IPartidaService partidaService)
        {
            _apiFutebolService = apiFutebolService;
            _paisService = paisService;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _competicaoService = competicaoService;
            _equipeService = equipeService;
            _partidaService = partidaService;
        }

        public async Task<int> SincronizarPaisesAsync()
        {
            try
            {
                var areasDto = await _apiFutebolService.ObterDadosAsync<AreasDTO>("areas");

                if (areasDto?.areas == null || !areasDto.areas.Any())
                    return 0;

                var paises = _paisService.ConverterAreasParaPaises(areasDto);
                List<Pais>? paisesNovos = _paisService.RemoverPaisesRepetidos(paises);

                if(paisesNovos != null && paisesNovos.Count > 0)
                {
                    await _paisService.AdicionarEmLoteAsync(paisesNovos);
                    await _unitOfWork.CommitAsync();

                    return paisesNovos.Count;
                }

                return 0;                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao sincronizar países.");
                throw;
            }
        }

        public async Task<int> SincronizarCompeticaoPorPaises()
        {
            try
            {
                var competicoesDto = await _apiFutebolService.ObterDadosAsync<CompeticoesDTO>("competitions");

                if (competicoesDto?.competitions == null || !competicoesDto.competitions.Any())
                    return 0;

                List<Competicao> competicoes = await _competicaoService.ConverterCompeticoes(competicoesDto);
                List<Competicao> novasCompeticoes = _competicaoService.RemoverCompeticoesRepetidas(competicoes);

                if(novasCompeticoes != null | novasCompeticoes.Count > 0)
                {
                    await _competicaoService.AdicionarEmLoteAsync(competicoes);
                    await _unitOfWork.CommitAsync();

                    return competicoes.Count;
                }

                return 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao sincronizar competições.");
                throw;
            }
        }

        public async Task<int> SincronizarTimesPorCompeticao(string codigoCompeticao)
        {
            try
            {
                var timesDto = await _apiFutebolService.ObterDadosAsync<TimesCompeticaoDTO>("competitions", codigoCompeticao + "/teams");

                if (timesDto?.teams == null || !timesDto.teams.Any())
                    return 0;

                List<Equipe> equipes = await _equipeService.ConverterTimes(timesDto);

                await _equipeService.AdicionarEmLoteAsync(equipes);
                await _unitOfWork.CommitAsync();

                return equipes.Count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao sincronizar times.");
                throw;
            }
        }

        public async Task<int> SincronizarPartidasPorCompeticoes(string codigoCompeticao)
        {
            try
            {
                var partidasDto = await _apiFutebolService.ObterDadosAsync<PartidaCompeticaoDTO>("competitions", codigoCompeticao + "/matches");

                if (partidasDto?.matches == null || !partidasDto.matches.Any())
                    return 0;

                List<Partida> partidas = await _partidaService.ConverterPartidas(partidasDto, codigoCompeticao);

                await _partidaService.AdicionarEmLoteAsync(partidas);
                await _unitOfWork.CommitAsync();

                return partidas.Count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao sincronizar partidas.");
                throw;
            }
            
        }
    }
}
