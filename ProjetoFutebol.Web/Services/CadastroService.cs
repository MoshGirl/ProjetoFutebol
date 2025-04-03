using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Web.Interfaces;
using ProjetoFutebol.Web.Response;
using ProjetoFutebol.Web.ViewModels;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjetoFutebol.Web.Services
{
    public class CadastroService : ICadastroService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IApiService _apiService;
        public CadastroService(IHttpContextAccessor httpContextAccessor, IApiService apiService)
        {
            _httpContextAccessor = httpContextAccessor;
            _apiService = apiService;
        }

        public async Task<CadastroResponse> CadastrarNovoUsuario(CadastroViewModel model)
        {
            var cadastroData = new {Nome = model.Nome, Email = model.Email, SenhaHash = model.Senha};

            return await _apiService.PostAsync<CadastroResponse>("auth/registrar", cadastroData);
        }
    }
}