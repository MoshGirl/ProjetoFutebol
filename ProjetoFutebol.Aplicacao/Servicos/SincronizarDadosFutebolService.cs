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
        private readonly ILogger<SincronizarDadosFutebolService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public SincronizarDadosFutebolService(IApiFutebolService apiFutebolService, IPaisService paisService, ILogger<SincronizarDadosFutebolService> logger, IUnitOfWork unitOfWork, ICompeticaoService competicaoService)
        {
            _apiFutebolService = apiFutebolService;
            _paisService = paisService;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _competicaoService = competicaoService;
        }

        public async Task<int> SincronizarPaisesAsync()
        {
            try
            {
                var areasDto = await _apiFutebolService.ObterDadosAsync<AreasDTO>("areas");

                if (areasDto?.areas == null || !areasDto.areas.Any())
                    return 0;

                var paises = _paisService.ConverterAreasParaPaises(areasDto);

                await _paisService.AdicionarEmLoteAsync(paises);
                await _unitOfWork.CommitAsync();

                return paises.Count;
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

                await _competicaoService.AdicionarEmLoteAsync(competicoes);
                await _unitOfWork.CommitAsync();

                return competicoes.Count;
            }
            catch (Exception)
            {

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

                return default(int);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
