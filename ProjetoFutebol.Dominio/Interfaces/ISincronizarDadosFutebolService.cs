namespace ProjetoFutebol.Dominio.Interfaces
{
    public interface ISincronizarDadosFutebolService
    {
        Task<int> SincronizarPaisesAsync();
        Task<int> SincronizarCompeticaoPorPaises();
    }
}