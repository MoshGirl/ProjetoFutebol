using ProjetoFutebol.Web.Response;
using ProjetoFutebol.Web.ViewModels;

namespace ProjetoFutebol.Web.Interfaces
{
    public interface ICadastroService
    {
        Task<CadastroResponse> CadastrarNovoUsuario(CadastroViewModel model);
    }
}