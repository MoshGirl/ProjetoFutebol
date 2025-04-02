namespace ProjetoFutebol.Dominio.Entidades
{
    public class Equipe
    {
        public int EquipeID { get; set; }
        public string NomeEquipe { get; set; }
        public string NomeAbreviado { get; set; }
        public string Sigla { get; set; }
        public string Escudo { get; set; }

        public virtual ICollection<EquipeCompeticao> Competicoes { get; set; } = new List<EquipeCompeticao>();
    }
}