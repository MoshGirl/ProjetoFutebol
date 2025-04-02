using Microsoft.EntityFrameworkCore;
using ProjetoFutebol.Aplicacao.Servicos;
using ProjetoFutebol.Aplicacao.Extensions;
using ProjetoFutebol.Dominio.Interfaces;
using ProjetoFutebol.Infraestrutura.Repositorios;
using ProjetoFutebol.Infraestrutura;
using Microsoft.OpenApi.Models;
using System.Reflection;
using ProjetoFutebol.Aplicacao.Servicos.EntidadesService;
using ProjetoFutebol.Dominio.Interfaces.EntidadesInterface;

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
            services.AddApplicationServices(Assembly.GetExecutingAssembly());
            services.AddApplicationServices();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IApiFutebolService, ApiFutebolService>();
            //services.AddScoped<ISincronizarDadosFutebolService, SincronizarDadosFutebolService>();
            //services.AddScoped<IPaisService, PaisService>();

            // Configuração do banco de dados
            services.AddDbContext<ProjetoFutebolDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Configuração do Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Projeto Futebol API",
                    Version = "v1",
                    Description = "API para gerenciamento de competições de futebol.",
                    Contact = new OpenApiContact
                    {
                        Name = "Anna Carollyne",
                        Email = "anna11bra@gmail.com",
                        Url = new Uri("https://github.com/MoshGirl")
                    }
                });

                // Adiciona suporte a comentários XML
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

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