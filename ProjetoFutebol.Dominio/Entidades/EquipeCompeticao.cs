using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFutebol.Dominio.Entidades
{
    public class EquipeCompeticao
    {
        public int EquipeID { get; set; }
        public Equipe Equipe { get; set; }

        public int CompeticaoID { get; set; }
        public Competicao Competicao { get; set; }
    }
}
