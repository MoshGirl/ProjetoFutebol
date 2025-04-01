using ProjetoFutebol.Dominio.Entidades.Time;
using System.Text.Json.Serialization;

namespace ProjetoFutebol.Dominio.Entidades.PartidaModels
{
    public class Placar
    {
        [JsonPropertyName("winner")]
        public TimeFutebol Vencedor { get; set; }

        [JsonPropertyName("duration")]
        public string Duracao { get; set; }

        [JsonPropertyName("fullTime")]
        public PlacarTemposDeJogo? PlacarFinal { get; set; }

        [JsonPropertyName("halfTime")]
        public PlacarTemposDeJogo? PrimeiroTempo { get; set; }
    }
}