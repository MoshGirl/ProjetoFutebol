using ProjetoFutebol.Web.DTOs;
using ProjetoFutebol.Web.Interfaces;
using ProjetoFutebol.Web.ViewModels;

namespace ProjetoFutebol.Web.Services
{
    public class PartidaService : IPartidaService
    {
        private readonly IApiService _apiService;
        private readonly IHttpContextAccessor _contextAccessor;

        public PartidaService(IApiService apiService, IHttpContextAccessor contextAccessor)
        {
            _apiService = apiService;
            _contextAccessor = contextAccessor;
        }

        public async Task<List<PartidaViewModel>> ObterPartidasDeHojeAsync()
        {
            var response = await _apiService.GetAsync<PartidasAtuaisDTO>("Futebol/partidas-hoje");

            if (response == null || response.matches == null)
                return new List<PartidaViewModel>();

            var partidas = response.matches.Select(m => new PartidaViewModel 
            {
                Competicao = m.competition.name,
                TimeCasa = m.homeTeam.name,
                TimeFora = m.awayTeam.name,
                PlacarCasa = m.score.fullTime?.home ?? 0,
                PlacarFora = m.score.fullTime?.away ?? 0,
                EmblemaCasa = m.homeTeam.crest,
                EmblemaFora = m.awayTeam.crest
            }).ToList();

            return partidas;
        }
    }
}