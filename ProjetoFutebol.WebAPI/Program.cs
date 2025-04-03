using ProjetoFutebol.Aplicacao.Extensions;
using ProjetoFutebol.WebAPI.Properties;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.WebHost.UseUrls("https://localhost:7015");
var app = builder.Build();

app.ConfigureMiddleware();

app.Run();