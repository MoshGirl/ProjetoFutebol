using ProjetoFutebol.Web.ViewModels;

namespace ProjetoFutebol.Web.Interfaces
{
    public interface ICampeonatoService
    {
        Task<List<CampeonatoViewModel>> ObterCampeonatosComPartidasAsync();
    }
}