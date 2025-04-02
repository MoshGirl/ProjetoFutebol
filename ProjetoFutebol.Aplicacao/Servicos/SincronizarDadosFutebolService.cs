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
        private readonly IRepository<Pais> _repositorioPais;
        private readonly ILogger<SincronizarDadosFutebolService> _logger;

        public SincronizarDadosFutebolService(IApiFutebolService apiFutebolService, IPaisService paisService, IRepository<Pais> repositorioPais, ILogger<SincronizarDadosFutebolService> logger)
        {
            _apiFutebolService = apiFutebolService;
            _paisService = paisService;
            _repositorioPais = repositorioPais;
            _logger = logger;
        }

        public async Task<int> SincronizarPaisesAsync()
        {
            try
            {
                var areasDto = await _apiFutebolService.ObterDadosAsync<AreasDTO>("areas");

                if (areasDto?.areas == null || !areasDto.areas.Any())
                    return 0;

                var paises = _paisService.ConverterAreasParaPaises(areasDto);
                await _repositorioPais.AdicionarEmLoteAsync(paises);

                return paises.Count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao sincronizar países.");
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


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
