using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjetoFutebol.Dominio.Entidades;
using ProjetoFutebol.Dominio.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetoFutebol.Aplicacao.Servicos
{
    public class AuthService :IAuthService
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IRepository<Usuario> usuarioRepository, IConfiguration config, IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _config = config;
            _unitOfWork = unitOfWork;
        }

        public async Task<Usuario?> AutenticarUsuarioAsync(string email, string senha)
        {
            var usuario = await BuscarUsuarioPorEmail(email);
            if (usuario == null || !VerificarSenha(senha, usuario.SenhaHash))
                return null;

            return usuario;
        }

        private bool VerificarSenha(string senha, string senhaHash)
        {
            return HashSenha(senha) == senhaHash;
        }

        public async Task<string> GerarTokenAsync(Usuario usuario)
        {
            var chaveSecreta = _config["Jwt:SecretKey"];
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.UsuarioID.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim("nome", usuario.Nome),
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credenciais);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Usuario> RegistrarUsuarioAsync(string nome, string email, string senha)
        {
            Usuario? usuarioExistente = await BuscarUsuarioPorEmail(email);

            if (usuarioExistente != null) { throw new Exception("Usuário já cadastrado."); }

            var senhaHash = HashSenha(senha);

            var usuario = new Usuario(nome, email, senhaHash);

            await _usuarioRepository.AdicionarAsync(usuario);
            await _unitOfWork.CommitAsync();

            return usuario;
        }

        private async Task<Usuario?> BuscarUsuarioPorEmail(string email)
        {
            return (await _usuarioRepository.BuscarAsync(x => x.Email.Equals(email))).FirstOrDefault();
        }

        private static string HashSenha(string senha)
        {
            byte[] salt = Encoding.UTF8.GetBytes("SALT_FIXO_PARA_DEMO");

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: senha,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}
