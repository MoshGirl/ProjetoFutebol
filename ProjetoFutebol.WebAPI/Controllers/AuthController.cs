using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Entidades;
using ProjetoFutebol.Dominio.Interfaces;

namespace ProjetoFutebol.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IRepository<Usuario> _usuarioRepository;

        public AuthController(IAuthService authService, IRepository<Usuario> usuarioRepository)
        {
            _authService = authService;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] CadastroDTO usuarioDto)
        {
            try
            {
                var usuario = await _authService.RegistrarUsuarioAsync(usuarioDto.Nome, usuarioDto.Email, usuarioDto.SenhaHash);
                return Ok(new { mensagem = "Usuário registrado com sucesso!", email = usuario.Email, status = 200 });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var usuario = await _authService.AutenticarUsuarioAsync(model.Email, model.Senha);

            if (usuario == null)
                return Unauthorized(new { mensagem = "Credenciais inválidas." });

            var token = await _authService.GerarTokenAsync(usuario);
            return Ok(new { token = token.ToString() });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var usuario = (await _usuarioRepository.BuscarAsync(u => u.RefreshToken == request.RefreshToken)).FirstOrDefault();

            if (usuario == null || usuario.RefreshTokenExpiracao < DateTime.UtcNow)
            {
                return Unauthorized("Refresh Token inválido ou expirado.");
            }

            var (novoToken, novoRefreshToken) = await _authService.GerarTokenAsync(usuario);

            return Ok(new { token = novoToken, refreshToken = novoRefreshToken });
        }
    }
}