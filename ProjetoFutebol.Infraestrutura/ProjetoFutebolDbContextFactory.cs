using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProjetoFutebol.Infraestrutura
{
    public class ProjetoFutebolDbContextFactory : IDesignTimeDbContextFactory<ProjetoFutebolDbContext>
    {
        public ProjetoFutebolDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ProjetoFutebolDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            return new ProjetoFutebolDbContext(optionsBuilder.Options);
        }
    }
}