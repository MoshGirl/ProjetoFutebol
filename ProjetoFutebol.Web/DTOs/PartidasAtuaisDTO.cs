namespace ProjetoFutebol.Web.DTOs
{
    public class PartidasAtuaisDTO
    {
        public List<Match> matches { get; set; }

        public class Match
        {
            public Competition competition { get; set; }
            public HomeTeam homeTeam { get; set; }
            public AwayTeam awayTeam { get; set; }
            public Score score { get; set; }
            public string status { get; set; }
        }

        public class Competition
        {
            public string name { get; set; }
        }

        public class HomeTeam
        {
            public string name { get; set; }
            public string crest { get; set; }
        }

        public class AwayTeam
        {
            public string name { get; set; }
            public string crest { get; set; }
        }

        public class Score
        {
            public FullTime fullTime { get; set; }
        }

        public class FullTime
        {
            public int? home { get; set; }
            public int? away { get; set; }
        }
    }
}