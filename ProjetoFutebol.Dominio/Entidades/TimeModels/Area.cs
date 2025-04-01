using System.Text.Json.Serialization;

namespace ProjetoFutebol.Dominio.Entidades.TimeModels
{
    public class Area
    {
        [JsonPropertyName("id")]
        public int AreaId { get; set; }

        [JsonPropertyName("name")]
        public string Nome { get; set; }

        [JsonPropertyName("code")]
        public string Codigo { get; set; }

        [JsonPropertyName("countryCode")]
        public string CodigoPais { get; set; }

        [JsonPropertyName("flag")]
        public string Bandeira { get; set; }

        [JsonPropertyName("parentAreaId")]
        public int? AreaPaiId { get; set; }

        [JsonPropertyName("parentArea")]
        public string AreaPai { get; set; }

        [JsonPropertyName("childAreas")]
        public ICollection<AreaFilha>? AreasFilhas { get; set; }
    }
}