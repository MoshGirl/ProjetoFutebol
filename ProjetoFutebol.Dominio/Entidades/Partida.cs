using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFutebol.Dominio.Entidades
{
    public class Partida
    {
        public int PartidaID { get; set; }
        public DateTime DataPartida { get; set; }
        public int CompeticaoID { get; set; }
        public int TimeDaCasaID { get; set; }
        public int TimeVisitanteID { get; set; }
        public int? PlacarID { get; set; }

        public virtual Competicao Competicao { get; set; }
        public virtual Equipe TimeDaCasa { get; set; }
        public virtual Equipe TimeVisitante { get; set; }
        public virtual Placar Placar { get; set; }
    }
}