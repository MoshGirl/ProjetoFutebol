using ProjetoFutebol.Dominio.Entidades.TemporadaModels;
using ProjetoFutebol.Dominio.Entidades.TimeModels;
using System.Text.Json.Serialization;

namespace ProjetoFutebol.Dominio.Entidades.Time
{
    public class Competicao
    {
        [JsonPropertyName("area")]
        public Area? Area { get; set; }

        [JsonPropertyName("id")]
        public int CompeticaoId { get; set; }

        [JsonPropertyName("name")]
        public string? Nome { get; set; }

        [JsonPropertyName("code")]
        public string? Codigo { get; set; }

        [JsonPropertyName("type")]
        public string? Tipo { get; set; }

        [JsonPropertyName("emblem")]
        public string Emblema { get; set; }

        [JsonPropertyName("currentSeason")]
        public Temporada? TemporadaAtual { get; set; }

        [JsonPropertyName("seasons")]
        public IEnumerable<Temporada>? Temporadas { get; set; }

        [JsonPropertyName("lastUpdated")]
        public DateTime UltimaAtualizacao { get; set; }
    }
}