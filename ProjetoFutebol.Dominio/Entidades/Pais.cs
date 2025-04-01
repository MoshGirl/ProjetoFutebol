namespace ProjetoFutebol.Dominio.Entidades
{
    public class Pais
    {
        public int PaisID { get; set; }
        public string NomePais { get; set; }
        public string CodigoPais { get; set; }

        public virtual ICollection<Competicao> Competicoes { get; set; } = new List<Competicao>();
    }
}