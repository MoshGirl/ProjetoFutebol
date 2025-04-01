namespace ProjetoFutebol.Dominio.DTOs
{
    public class AreasDTO
    {
        public int count { get; set; }
        public Filters filters { get; set; }
        public List<Area> areas { get; set; }
    }

    public class Area
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? countryCode { get; set; }
        public string? flag { get; set; }
        public int? parentAreaId { get; set; }
        public string? parentArea { get; set; }
    }

    public class Filters
    {
    }
}