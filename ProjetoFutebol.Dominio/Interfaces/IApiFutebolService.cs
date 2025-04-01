namespace ProjetoFutebol.Dominio.Interfaces
{
    public interface IApiFutebolService
    {
        Task<T> GetAsync<T>(string endpoint);
    }
}