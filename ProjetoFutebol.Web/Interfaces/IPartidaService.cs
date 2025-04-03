using ProjetoFutebol.Web.ViewModels;

namespace ProjetoFutebol.Web.Interfaces
{
    public interface IPartidaService
    {
        Task<List<PartidaViewModel>> ObterPartidasDeHojeAsync();
    }
}