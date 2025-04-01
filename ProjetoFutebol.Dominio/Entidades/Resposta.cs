using ProjetoFutebol.Dominio.Entidades.TemporadaModels;
using ProjetoFutebol.Dominio.Entidades.TimeModels;
using System.Text.Json.Serialization;

namespace ProjetoFutebol.Dominio.Entidades
{
    public class Resposta
    {
        [JsonPropertyName("count")]
        public int Contador { get; set; }

        [JsonPropertyName("filters")]
        public Filtro? Filtro { get; set; }

        [JsonPropertyName("areas")]
        public List<Area> Areas { get; set; }
    }
}