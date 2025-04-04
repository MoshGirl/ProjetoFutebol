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

            throw new NotImplementedException();
        }
    }
}