using Microsoft.EntityFrameworkCore;
using ProjetoFutebol.Dominio.Interfaces;
using System.Linq.Expressions;

namespace ProjetoFutebol.Infraestrutura.Repositorios
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ProjetoFutebolDbContext _context;

        public Repository(ProjetoFutebolDbContext context)
        {
            _context = context;
        }

        public async Task<T> AdicionarAsync(T entidade)
        {
            await _context.Set<T>().AddAsync(entidade);
            return entidade;
        }

        public Task<T> AtualizarAsync(T entidade)
        {
            _context.Set<T>().Update(entidade);
            return Task.FromResult(entidade);
        }

        public Task<bool> RemoverAsync(T entidade)
        {
            _context.Set<T>().Remove(entidade);
            return Task.FromResult(true);
        }

        public async Task<T?> ObterPorIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> filtro)
        {
            return await _context.Set<T>().Where(filtro).ToListAsync();
        }
    }
}