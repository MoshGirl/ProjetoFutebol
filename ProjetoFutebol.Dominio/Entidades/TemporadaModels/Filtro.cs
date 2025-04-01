using System.Text.Json.Serialization;

namespace ProjetoFutebol.Dominio.Entidades.TemporadaModels
{
    public class Filtro
    {
        [JsonPropertyName("season")]
        public string? AnoTemporada { get; set; }

        [JsonPropertyName("competitions")]
        public string? Competicoes { get; set; }

        [JsonPropertyName("permission")]
        public string? Permissao { get; set; }

        [JsonPropertyName("limit")]
        public int? Limite { get; set; }
    }
}