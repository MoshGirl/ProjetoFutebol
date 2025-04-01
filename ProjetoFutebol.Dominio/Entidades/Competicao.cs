namespace ProjetoFutebol.Dominio.Entidades
{
    public class Competicao
    {
        public int CompeticaoID { get; set; }
        public string NomeCompeticao { get; set; }
        public string Codigo { get; set; }
        public string TipoCompeticao { get; set; }
        public string Temporada { get; set; }
        public int PaisID { get; set; }

        public virtual Pais Pais { get; set; }
        public virtual ICollection<EquipeCompeticao> EquipesCompeticao { get; set; } = new List<EquipeCompeticao>();
        public virtual ICollection<Partida> Partidas { get; set; }
    }
}