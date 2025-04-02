using ProjetoFutebol.Dominio.Entidades;

namespace ProjetoFutebol.Dominio.Interfaces
{
    public interface IAuthService
    {
        Task<Usuario> RegistrarUsuarioAsync(string nome, string email, string senha);
        Task<(string token, string refreshToken)> GerarTokenAsync(Usuario usuario);
        Task<Usuario?> AutenticarUsuarioAsync(string email, string senha);
    }
}