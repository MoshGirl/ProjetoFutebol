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

        public async Task AdicionarEmLoteAsync<T>(IEnumerable<T> entidades) where T : class
        {
            var set = _context.Set<T>();

            var idProperty = typeof(T).GetProperties().FirstOrDefault(p => p.Name.EndsWith("ID", StringComparison.OrdinalIgnoreCase));

            if (idProperty == null)
                throw new InvalidOperationException($"A entidade {typeof(T).Name} não possui uma propriedade de ID.");

            var ids = entidades.Select(e => idProperty.GetValue(e)).Where(id => id != null).ToList();

            var idsExistentes = await set
                .Where(e => ids.Contains(EF.Property<object>(e, idProperty.Name)))
                .Select(e => EF.Property<object>(e, idProperty.Name))
                .ToListAsync();

            var novasEntidades = entidades
                .Where(e => !idsExistentes.Contains(idProperty.GetValue(e)))
                .ToList();

            foreach (var entidade in novasEntidades)
            {
                idProperty.SetValue(entidade, null);
            }

            if (novasEntidades.Any())
            {
                await set.AddRangeAsync(novasEntidades);
            }
        }

        public async Task<T?> ObterPorIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T?> ObterPorCodigoAsync(string codigo)
        {
            return await _context.Set<T>().FindAsync(codigo);
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