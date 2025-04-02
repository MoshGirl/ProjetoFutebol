using System.ComponentModel.DataAnnotations;

namespace ProjetoFutebol.Dominio.Entidades
{
    public class Usuario
    {
        public Usuario(string nome, string email, string senhaHash)
        {
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
        }

        public int UsuarioID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength (100)]
        public string Email { get; set; }

        [Required]
        public string SenhaHash { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiracao { get; set; }

        public void AtualizaRefreshToken(string refreshToken, int diasExpiracao)
        {
            RefreshToken = refreshToken;
            RefreshTokenExpiracao = DateTime.UtcNow.AddDays(diasExpiracao);
        }
    }
}