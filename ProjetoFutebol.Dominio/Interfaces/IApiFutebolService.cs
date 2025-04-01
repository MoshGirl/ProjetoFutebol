namespace ProjetoFutebol.Dominio.Interfaces
{
    public interface IApiFutebolService
    {
        Task<T> ObterDadosAsync<T>(string endpoint, string? parametro = null);
    }
}