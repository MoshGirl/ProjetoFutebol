using Microsoft.AspNetCore.Mvc;
using ProjetoFutebol.Dominio.Entidades;
using ProjetoFutebol.Dominio.Interfaces;

namespace ProjetoFutebol.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] Usuario usuarioDto)
        {
            try
            {
                var usuario = await _authService.RegistrarUsuarioAsync(usuarioDto.Nome, usuarioDto.Email, usuarioDto.SenhaHash);
                return Ok(new { mensagem = "Usuário registrado com sucesso!", usuario.Email });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string senha)
        {
            var usuario = await _authService.AutenticarUsuarioAsync(email, senha);

            if (usuario == null)
                return Unauthorized(new { mensagem = "Credenciais inválidas." });

            var token = await _authService.GerarTokenAsync(usuario);
            return Ok(new { token });
        }
    }
}