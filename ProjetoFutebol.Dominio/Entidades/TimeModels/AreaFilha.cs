using System.Text.Json.Serialization;

namespace ProjetoFutebol.Dominio.Entidades.TimeModels
{
    public class AreaFilha
    {
        [JsonPropertyName("id")]
        public int AreaFilhaId { get; set; }

        [JsonPropertyName("name")]
        public string Nome { get; set; }

        [JsonPropertyName("countryCode")]
        public string CodigoPais { get; set; }

        [JsonPropertyName("flag")]
        public string Bandeira { get; set; }

        [JsonPropertyName("parentAreaId")]
        public int AreaPaiId { get; set; }

        [JsonPropertyName("parentArea")]
        public string AreaPai { get; set; }
    }
}