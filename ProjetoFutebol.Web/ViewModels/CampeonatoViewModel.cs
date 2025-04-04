namespace ProjetoFutebol.Web.ViewModels
{
    public class CampeonatoViewModel
    {
        public int CampeonatoID { get; set; }
        public string Nome { get; set; }
        public string Emblema { get; set; }
        public List<PartidaViewModel> Partidas { get; set; } = new();
    }
}