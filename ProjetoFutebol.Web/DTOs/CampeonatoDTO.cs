namespace ProjetoFutebol.Web.DTOs
{
    public class CampeonatoDTO
    {
        public int CompeticaoID { get; set; }
        public string NomeCompeticao { get; set; }
        public string Codigo { get; set; }
        public string TipoCompeticao { get; set; }
        public string Temporada { get; set; }
        public int PaisID { get; set; }
        public string Emblema { get; set; }

        public List<EquipeDTO> Equipes { get; set; }
    }
}