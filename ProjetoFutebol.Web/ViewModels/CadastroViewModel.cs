using System.ComponentModel.DataAnnotations;

namespace ProjetoFutebol.Web.ViewModels
{
    public class CadastroViewModel
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MinLength(3)]
        public string Nome { get; set; }

        [Display(Name = "Endereço de E-mail")]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirme sua Senha")]
        [Required(ErrorMessage = "A confirme a senha.")]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmarSenha { get; set; }
    }
}