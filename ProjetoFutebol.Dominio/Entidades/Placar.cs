namespace ProjetoFutebol.Dominio.Entidades
{
    public class Placar
    {
        public int PlacarID { get; set; }
        public int PartidaID { get; set; }
        public int? VencedorID { get; set; }
        public int PlacarVisitante { get; set; }
        public int PlacarTimeDaCasa { get; set; }

        public virtual Partida Partida { get; set; }
        public virtual Equipe Vencedor { get; set; }
    }
}