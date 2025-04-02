using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Entidades;
using ProjetoFutebol.Dominio.Interfaces;
using Microsoft.Extensions.Logging;

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
    }
}
