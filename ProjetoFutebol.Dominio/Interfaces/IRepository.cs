using System.Linq.Expressions;

namespace ProjetoFutebol.Dominio.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> AdicionarAsync(T entidade);
        Task<T> AtualizarAsync(T entidade);
        Task<bool> RemoverAsync(T entidade);
        Task AdicionarEmLoteAsync<T>(IEnumerable<T> entidades) where T : class;
        Task<T?> ObterPorIdAsync(int id);
        Task<T?> ObterPorCodigoAsync(string codigo);
        Task<IEnumerable<T>> ObterTodosAsync();
        Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> filtro);
    }
}