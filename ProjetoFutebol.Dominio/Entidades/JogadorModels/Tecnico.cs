using System.Text.Json.Serialization;

namespace ProjetoFutebol.Dominio.Entidades.JogadorModels
{
    public class Tecnico
    {
        [JsonPropertyName("id")]
        public int TecnicoId { get; set; }

        [JsonPropertyName("name")]
        public string? Nome { get; set; }

        [JsonPropertyName("nationality")]
        public string? Nacionalidade { get; set; }
    }
}