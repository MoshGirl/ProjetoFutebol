namespace ProjetoFutebol.Dominio.DTOs
{
    public class TimesCompeticaoDTO
    {
        public int count { get; set; }
        public Competition competition { get; set; }
        public Season season { get; set; }
        public List<Team> teams { get; set; }

        public class Area
        {
            public int id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
            public string flag { get; set; }
        }

        public class Competition
        {
            public int id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
            public string type { get; set; }
            public string emblem { get; set; }
        }

        public class Season
        {
            public int id { get; set; }
            public string startDate { get; set; }
            public string endDate { get; set; }
            public int currentMatchday { get; set; }
            public object winner { get; set; }
        }

        public class Team
        {
            public Area area { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string shortName { get; set; }
            public string tla { get; set; }
            public string crest { get; set; }
            public List<RunningCompetitions> runningCompetitions { get; set; }
        }

        public class RunningCompetitions 
        {
            public int id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
        }
    }
}