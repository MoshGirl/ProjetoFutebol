using ProjetoFutebol.Web.DTOs;
using ProjetoFutebol.Web.Interfaces;
using ProjetoFutebol.Web.ViewModels;

namespace ProjetoFutebol.Web.Services
{
    public class CampeonatoService : ICampeonatoService
    {
        private readonly IApiService _apiService;

        public CampeonatoService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<CampeonatoViewModel>> ObterCampeonatosComPartidasAsync()
        {
            var dtoList = await _apiService.GetAsync<List<CampeonatoDTO>>("Futebol/competicoes");

            if (dtoList == null || !dtoList.Any())
            {
                return new List<CampeonatoViewModel>();
            }

            var viewModelList = dtoList
           .Where(dto => dto != null)
           .Select(dto => new CampeonatoViewModel
           {
               CompeticaoID = dto.CompeticaoID,
               NomeCompeticao = dto.NomeCompeticao ?? "Desconhecida",
               Codigo = dto.Codigo ?? "N/A",
               TipoCompeticao = dto.TipoCompeticao ?? "N/A",
               Temporada = dto.Temporada ?? "N/A",
               PaisID = dto.PaisID,
               Emblema = dto.Emblema ?? string.Empty,
               Equipes = dto.Equipes?
                   .Where(eq => eq != null)
                   .Select(eq => new EquipeViewModel
                   {
                       EquipeID = eq.EquipeID,
                       NomeEquipe = eq.NomeEquipe ?? "Sem nome",
                       NomeAbreviado = eq.NomeAbreviado ?? "-",
                       Sigla = eq.Sigla ?? "---",
                       Escudo = eq.Escudo ?? ""
                   }).ToList() ?? new List<EquipeViewModel>()
           }).ToList();

            return viewModelList;
        }
    }
}