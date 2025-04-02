using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjetoFutebol.Aplicacao.Extensions;
using ProjetoFutebol.Aplicacao.Servicos;
using ProjetoFutebol.Dominio.Interfaces;
using ProjetoFutebol.Infraestrutura;
using ProjetoFutebol.Infraestrutura.Repositorios;
using System.Reflection;
using System.Text;

namespace ProjetoFutebol.WebAPI.Properties
{
    public static class ServiceExtensions
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var chaveSecreta = Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(chaveSecreta)
                    };
                });
        }

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddHttpClient<ApiFutebolService>();

            // Injeção de Dependência
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddApplicationServices(Assembly.GetExecutingAssembly());
            services.AddApplicationServices();
            services.AddScoped<IAuthService, AuthService>();
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

                // Configurar autenticação JWT no Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Insira o token JWT no formato: Bearer {seu_token}"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                     {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
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