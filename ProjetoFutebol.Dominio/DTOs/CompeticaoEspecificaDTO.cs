namespace ProjetoFutebol.Dominio.DTOs
{
    public class CompeticaoEspecificaDTO
    {
        public Area area { get; set; }
        public int? id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string type { get; set; }
        public string emblem { get; set; }
        public CurrentSeason currentSeason { get; set; }
        //public List<Season> seasons { get; set; }
        public DateTime? lastUpdated { get; set; }

        public class Area
        {
            public int? id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
            public string flag { get; set; }
        }

        public class CurrentSeason
        {
            public int? id { get; set; }
            public string startDate { get; set; }
            public string endDate { get; set; }
            public int? currentMatchday { get; set; }
            public object winner { get; set; }
        }
    }
}