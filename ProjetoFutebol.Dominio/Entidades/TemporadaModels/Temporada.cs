using ProjetoFutebol.Dominio.Entidades.Time;
using System.Text.Json.Serialization;

namespace ProjetoFutebol.Dominio.Entidades.TemporadaModels
{
    public class Temporada
    {
        [JsonPropertyName("id")]
        public int TemporadaId { get; set; }

        [JsonPropertyName("startDate")]
        public DateTime? DataInicio { get; set; }

        [JsonPropertyName("endDate")]
        public DateTime? DataFim { get; set; }

        [JsonPropertyName("currentMatchday")]
        public int? RodadaAtual { get; set; }

        [JsonPropertyName("winner")]
        public TimeFutebol? Vencedor { get; set; }

        [JsonPropertyName("stages")]
        public List<string>? Fases { get; set; }
    }
}