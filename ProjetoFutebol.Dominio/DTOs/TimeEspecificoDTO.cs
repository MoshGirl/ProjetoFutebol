namespace ProjetoFutebol.Dominio.DTOs
{
    public class TimeEspecificoDTO
    {
        public Area area { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string tla { get; set; }
        public string crest { get; set; }
        public List<RunningCompetition> runningCompetitions { get; set; }

        public class RunningCompetition
        {
            public int id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
            public string type { get; set; }
            public string emblem { get; set; }
        }

        public class Area
        {
            public int id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
            public string flag { get; set; }
        }
    }
}