using Microsoft.EntityFrameworkCore;
using ProjetoFutebol.Aplicacao.Servicos;
using ProjetoFutebol.Dominio.Interfaces;
using ProjetoFutebol.Infraestrutura.Repositorios;
using ProjetoFutebol.Infraestrutura;

namespace ProjetoFutebol.WebAPI.Properties
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddHttpClient<ApiFutebolService>();

            // Injeção de Dependência
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Configuração do banco de dados
            services.AddDbContext<ProjetoFutebolDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Configuração do Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Configuração do CORS
            services.AddCors(options =>
            {
                options.AddPolicy("_myCorsPolicy", policy =>
                {
                    policy.WithOrigins(configuration["AllowedOrigins"] ?? "https://localhost:5001")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
        }
    }
}