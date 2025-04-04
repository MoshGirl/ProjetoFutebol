namespace ProjetoFutebol.Web.ViewModels
{
    public class EquipeViewModel
    {
        public int EquipeID { get; set; }
        public string NomeEquipe { get; set; } = string.Empty;
        public string NomeAbreviado { get; set; } = string.Empty;
        public string Sigla { get; set; } = string.Empty;
        public string Escudo { get; set; } = string.Empty;
    }
}