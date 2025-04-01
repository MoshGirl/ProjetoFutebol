using System.Text.Json.Serialization;

namespace ProjetoFutebol.Dominio.Entidades.TemporadaModels
{
    public class Classificacao
    {
        [JsonPropertyName("stage")]
        public string Fase { get; set; }

        [JsonPropertyName("type")]
        public string Tipo { get; set; }

        [JsonPropertyName("group")]
        public object Grupo { get; set; }

        [JsonPropertyName("table")]
        public IEnumerable<Tabela> Tabelas { get; set; }
    }
}
