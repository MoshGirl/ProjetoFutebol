using System.Text.Json.Serialization;

namespace ProjetoFutebol.Dominio.Entidades.PartidaModels
{
    public class PlacarTemposDeJogo
    {
        [JsonPropertyName("home")]
        public int? Casa { get; set; }

        [JsonPropertyName("away")]
        public int? Visitante { get; set; }
    }
}