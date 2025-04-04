namespace ProjetoFutebol.Web.ViewModels
{
    public class CampeonatoViewModel
    {
        public int CompeticaoID { get; set; }
        public string NomeCompeticao { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string TipoCompeticao { get; set; } = string.Empty;
        public string Temporada { get; set; } = string.Empty;
        public int PaisID { get; set; }
        public string Emblema { get; set; } = string.Empty;

        public List<EquipeViewModel> Equipes { get; set; } = new();
    }
}