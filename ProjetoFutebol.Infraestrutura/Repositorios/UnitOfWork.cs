using ProjetoFutebol.Dominio.Interfaces;

namespace ProjetoFutebol.Infraestrutura.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjetoFutebolDbContext _context;

        public UnitOfWork(ProjetoFutebolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}